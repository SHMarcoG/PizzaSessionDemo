using System.Net.Http.Headers;
using System;
using PizzaSessionDemo.Models;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using PizzaSessionDemo;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;


string uri = "xxxx";
string urlParameters = "gettoken?";


// Create a new instance from the API caller class
APICaller api = new APICaller(uri);

// Use the API Instance and use the GetCall method
string data = api.GetCall(urlParameters);

//Convert the return jsonstring to a Model
Token tokendata = JsonConvert.DeserializeObject<Token>(data);

// Get the bearer token from the token model
string token = tokendata.bearertoken;
Console.WriteLine(token);

//This line is to prevent the application to close automatically
Console.ReadLine();
