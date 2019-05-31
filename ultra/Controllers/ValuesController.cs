using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ultrasonic.Models;
using Ultrasonic.Repository;
using MySql.Data.MySqlClient;

namespace Ultrasonic.Controllers
{
    public class userController : ApiController
    {
        /// <summary>  
        /// Insert user to database  
        /// </summary> 
        [HttpPost]
        [Route("api/save/value")]
        public HttpResponseMessage Postvalue(Value value)
        {
            //bool result = false;
            string text = "";
            string errMessage = "";
            try
            {
                var query = string.Format("INSERT INTO value(id, distance) VALUES ('{0}', '{1}')", value.id, value.distance); //SQL query language
                ValueRepository.ReadData(query);

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
        [Route("api/get/value")]
        public HttpResponseMessage Getvalue()
        {
            //bool result = false;            
            string errMessage = "";
            ListValue list_value = new ListValue();
            string SQL = "SELECT * from value where distance=10";
            DataSet ds = ValueRepository.ReadData(SQL);
            list_value.number = ds.Tables[0].Rows.Count;
            if (ds.Tables[0].Rows.Count > 0)
            {
                //list_user.number = ds.Tables[0].Rows.Count;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Value item = new Value()
                    {
                        id = dr["id"].ToString(),
                        distance = dr["distance"].ToString(),
                    };

                    list_value.values.Add(item);
                }
            }
            if (errMessage != "")
                return Request.CreateResponse(HttpStatusCode.InternalServerError, errMessage);
            else
                //Console.WriteLine(HttpStatusCode.OK);
                //return Request.CreateResponse(HttpStatusCode.OK, result); 
                return Request.CreateResponse(HttpStatusCode.OK, list_value);
        }

        /// <summary>  
        /// Delete user from database by user_id 
        /// </summary>
        [HttpPost]
        [Route("api/delete/value")]
        public HttpResponseMessage Deletevalue(Value value)
        {
            string text = "";
            string errMessage = "";

            try
            {
                string query = string.Format("DELETE from value WHERE id = '{0}'", value.id);
                ValueRepository.ReadData(query);
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
        [HttpPost]
        [Route("api/update/value")]
        public HttpResponseMessage Updatevalue(Value value)
        {
            string text = "";
            string errMessage = "";


            try
            {
                string query = string.Format("UPDATE value set distance = '{0}' WHERE id = '{1}' ", value.distance, value.id);
                //query = query.Replace("@user_id", user.user_id);
                //query = query.Replace("@user_n", user.user_name);  
                ValueRepository.ReadData(query);
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
                text = "Update finish!";
                return Request.CreateResponse(HttpStatusCode.OK, text);
            }
        }

    }
}