using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

/// <summary>
/// example method for making a simple communication request to the web server API - no serialization/deserialization of objects necessary (b/c request returns simple data types)
/// </summary>
/// <param name="deviceTag"></param>
/// <returns></returns>
        public async Task<bool> ExampleSimplePermissionRequest(string deviceTag)
        {
            bool hasPermission = false;

            var fullUri = new Uri(_httpClient.BaseAddress, @"api/Permissions/Example");

            try
            {
                // create the Http Request
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, fullUri)
                {
                    Content = new StringContent(deviceTag)
                };

                // send the request
                HttpResponseMessage response = await _httpClient.SendAsync(requestMessage);

                // interpret the response
                // the PipelineErrorResponseHandler and validationHandler may have already caught any bad responses
                var jsonResponseBody = await response.Content.ReadAsStringAsync();
                // the strings we expect back are going to be either "true" or "false"
                hasPermission = jsonResponseBody == "true";
            }
            catch (Exception exception)
            {
                // an exception here may be because one of the Pipeline handlers encountered an error or bad response.
                _logger.Log(LogLevel.Error, exception, $"Exception ({exception.Message}) while requesting post at {fullUri} at {DateTime.Now} in DeviceViewCommService");

                // todo - what to return in error cases?
            }

            return hasPermission;
        }



/// <summary>
/// example method for making a simple communication request to the web server API - serialization/deserialization of objects
/// </summary>
/// <param name="deviceTag"></param>
/// <returns></returns>
public async Task<bool> ExampleComplexPermissionRequest(string deviceTag)
        {
            bool hasPermission = false;

            var fullUri = new Uri(_httpClient.BaseAddress, @"api/Permissions/Example");

            try
            {
                // create the body of the request
                // This is really not needed for something as simple as a string though.
                var jsonRequestBody = JsonConvert.SerializeObject(deviceTag, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        // use TypeNameHanding None unless we create custom binding for validation
                        TypeNameHandling = TypeNameHandling.None
                    });

                // create the Http Request
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, fullUri)
                {
                    Content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json")
                };

                // send the request
                HttpResponseMessage response = await _httpClient.SendAsync(requestMessage);

                // interpret the response
                // the following check may already be handled in the pipeline depending on how we implement PipelineErrorResponseHandler
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponseBody = await response.Content.ReadAsStringAsync();

                    // don't need to do this for something simple like a bool value, this is just an example
                    var deserializerSettings = new JsonSerializerSettings()
                    {
                        // use TypeNameHanding None unless we create custom binding for validation
                        TypeNameHandling = TypeNameHandling.None
                    };
                    hasPermission = JsonConvert.DeserializeObject<bool>(jsonResponseBody, deserializerSettings);
                }
                else
                {
                    // todo - what to return in error cases?
                }
            }
            catch (Exception exception)
            {
                // any exceptions at this point are a result of serialization, deserialization, constructing requests, or constructing results since
                // all the other exceptions have been caught by the handlers in the pipeline
                _logger.Log(LogLevel.Error, exception, $"Exception ({exception.Message}) while requesting post at {fullUri} at {DateTime.Now} in DeviceViewCommService");

                // todo - what to return in error cases?
            }

            return hasPermission;
        }
