using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using device.Models;
using device.Repository;
using MySql.Data.MySqlClient;

namespace device.Controllers
{
    public class DeviceController : ApiController
    {
        /// <summary>  
        /// Insert user to database  
        /// </summary> 
        [HttpPost]
        [Route("api/post/device")]
        public HttpResponseMessage Postdevice(Device device)
        {
            //bool result = false;
            string text = "";
            string errMessage = "";
            try
            {
                var query = string.Format("INSERT INTO device(id, room, status) VALUES ('{0}', '{1}', '{2}')", 
                    device.id, device.room, device.status); //SQL query language
                DeviceRepository.ReadData(query);
            }
            catch (Exception err)
            {
                errMessage = err.Message;
            }
            if (errMessage != "")
                return Request.CreateResponse(HttpStatusCode.InternalServerError, errMessage);
            else
            {
                text = "Save finish!";
                return Request.CreateResponse(HttpStatusCode.OK, text);
            }
        }

        /// <summary>  
        /// Get all user from database
        /// </summary>
        [HttpGet]  // Define method saveuser to do POST
        [Route("api/get/device")]
        public HttpResponseMessage Getdevice()
        {
            //bool result = false;            
            string errMessage = "";
            ListDevice list_device = new ListDevice();
            string SQL = "SELECT id,room,status from device";
            DataSet ds = DeviceRepository.ReadData(SQL);
            //list_device.number = ds.Tables[0].Rows.Count;
            if (ds.Tables[0].Rows.Count > 0)
            {
                //list_user.number = ds.Tables[0].Rows.Count;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Device item = new Device()
                    {
                        id = dr["id"].ToString(),
                        room = dr["room"].ToString(),
                        status = dr["status"].ToString(),
                    };

                    list_device.devices.Add(item);
                }
            }
            if (errMessage != "")
                return Request.CreateResponse(HttpStatusCode.InternalServerError, errMessage);
            else
                //Console.WriteLine(HttpStatusCode.OK);
                //return Request.CreateResponse(HttpStatusCode.OK, result); 
                return Request.CreateResponse(HttpStatusCode.OK, list_device);
        }

        /// <summary>  
        /// Delete user from database by user_id 
        /// </summary>
        [HttpPost]
        [Route("api/delete/device")]
        public HttpResponseMessage Deletevalue(Device device)
        {
            string text = "";
            string errMessage = "";

            try
            {
                string query = string.Format("DELETE from device WHERE id = '{0}'", device.id);
                DeviceRepository.ReadData(query);
            }
            //list_user.number = ds.Tables[0].Rows.Count;
            catch (Exception err)
            {
                errMessage = err.Message;
            }
            if (errMessage != "")
                return Request.CreateResponse(HttpStatusCode.InternalServerError, errMessage);
            else
            {
                text = "Delete finish";
                return Request.CreateResponse(HttpStatusCode.OK, text);
            }
        }

        /// <summary>  
        /// Edit user in database by choose user_id to change user_name
        /// </summary>
        //[HttpPost]
        //[Route("api/update/device")]
        //public HttpResponseMessage Updatevalue(Device device)
        //{
        //    string text = "";
        //    string errMessage = "";


        //    try
        //    {
        //        string query = string.Format("UPDATE device set status = '{0}' WHERE id = '{1}' ", device.status, device.id);
        //        //query = query.Replace("@user_id", user.user_id);
        //        //query = query.Replace("@user_n", user.user_name);  
        //        DeviceRepository.ReadData(query);
        //    }
        //    //list_user.number = ds.Tables[0].Rows.Count;
        //    catch (Exception err)
        //    {
        //        errMessage = err.Message;
        //    }


        //    if (errMessage != "")
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, errMessage);

        //    else
        //    {
        //        text = "Update finish!";
        //        return Request.CreateResponse(HttpStatusCode.OK, text);
        //    }
        //}

        [HttpPost]
        [Route("api/control/device/{id}/{status}")]
        public HttpResponseMessage ControlDevice(int id, int status, Device device)
        {
            string text = "";
            string errMessage = "";
            //Device device = new Device();

            try
            {
                string query = string.Format("UPDATE device set status = '{0}' WHERE id = '{1}' ", status, id);
                //query = query.Replace("@device_id", device.device_id);
                //query = query.Replace("@device_n", device.device_name);  
                DeviceRepository.ReadData(query);
            }
            //list_device.number = ds.Tables[0].Rows.Count;
            catch (Exception err)
            {
                errMessage = err.Message;
            }


            if (errMessage != "")
                return Request.CreateResponse(HttpStatusCode.InternalServerError, errMessage);

            else
            {
                text = "Update finish!";
                return Request.CreateResponse(HttpStatusCode.OK, text);
            }
        }

    }
}