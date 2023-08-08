﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using ValidationForm.Models;

namespace ValidationForm.Repository
{
    public class ValidationRepo
    {

        public readonly string connectionString;


        public ValidationRepo()
        {

            connectionString = connectionString = @"Data source=DESKTOP-8VD1A1F\SQLEXPRESS;Initial catalog=Validation;User Id=sa;Password=Anaiyaan@123"; ;
        }


        public void InsertValidation(ValidationModel info)
        {
            try
            {

                SqlConnection connectionObject = new SqlConnection(connectionString);

                connectionObject.Open();
                connectionObject.Execute($"exec InsertValidation '{info.Name}', '{info.Lastname}',{info.Email}, {info.Pnone} ");

                connectionObject.Close();

            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public List<ValidationModel> Selectvalidation()

        {
            try
            {
                List<ValidationModel> ListofPersonalData = new List<ValidationModel>();

                var connection = new SqlConnection(connectionString);
                connection.Open();
                ListofPersonalData = connection.Query<ValidationModel>("exec SelectValidation", connectionString).ToList();
                connection.Close();



                return ListofPersonalData;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public ValidationModel SelectValidationID(int id)
        {
            try
            {

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                var res = connection.QueryFirst<ValidationModel>($"exec selectsvalidationID {id}");
                connection.Close();

                return res;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ubdateValidation(ValidationModel info)
        {
            try
            {
                SqlConnection connectionObject = new SqlConnection(connectionString);



                connectionObject.Open();

                connectionObject.Execute($"  exec UbdateValidation ''{info.Name}', '{info.Lastname}',{info.Email}, {info.Pnone},'{info.id}' ");


                connectionObject.Close();
            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void deletevalidation(int id)
        {
            try
            {
                SqlConnection connectionObject = new SqlConnection(connectionString);

                connectionObject.Open();
                connectionObject.Execute($"exec DeleteValidation {id} ");


                connectionObject.Close();
            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
