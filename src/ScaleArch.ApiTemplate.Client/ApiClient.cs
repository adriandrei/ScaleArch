﻿//using Azure.Core.Pipeline;
//using Azure.Core;
//using Azure;

//namespace ScaleArch.ApiTemplate.Client
//{
//    public partial class ApiClient
//    {
//        private readonly HttpPipeline _pipeline;
//        private readonly Uri _endpoint;

//        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
//        internal ClientDiagnostics ClientDiagnostics { get; }

//        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
//        public virtual HttpPipeline Pipeline => _pipeline;

//        /// <summary> Initializes a new instance of ApiClient. </summary>
//        public ApiClient() : this(new Uri(""), new ApiClientOptions())
//        {
//        }

//        /// <summary> Initializes a new instance of ApiClient. </summary>
//        /// <param name="endpoint"> server parameter. </param>
//        /// <param name="options"> The options for configuring the client. </param>
//        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
//        public ApiClient(Uri endpoint, ApiClientOptions options)
//        {
//            Argument.AssertNotNull(endpoint, nameof(endpoint));
//            options ??= new ApiClientOptions();

//            ClientDiagnostics = new ClientDiagnostics(options, true);
//            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
//            _endpoint = endpoint;
//        }

//        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
//        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
//        /// <returns> The response returned from the service. </returns>
//        /// <example>
//        /// This sample shows how to call GetApisAsync and parse the result.
//        /// <code><![CDATA[
//        /// var client = new ApiClient();
//        /// 
//        /// Response response = await client.GetApisAsync();
//        /// 
//        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
//        /// Console.WriteLine(result[0].ToString());
//        /// ]]></code>
//        /// </example>
//        public virtual async Task<Response> GetApisAsync(RequestContext context = null)
//        {
//            using var scope = ClientDiagnostics.CreateScope("ApiClient.GetApis");
//            scope.Start();
//            try
//            {
//                using HttpMessage message = CreateGetApisRequest(context);
//                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
//            }
//            catch (Exception e)
//            {
//                scope.Failed(e);
//                throw;
//            }
//        }

//        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
//        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
//        /// <returns> The response returned from the service. </returns>
//        /// <example>
//        /// This sample shows how to call GetApis and parse the result.
//        /// <code><![CDATA[
//        /// var client = new ApiClient();
//        /// 
//        /// Response response = client.GetApis();
//        /// 
//        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
//        /// Console.WriteLine(result[0].ToString());
//        /// ]]></code>
//        /// </example>
//        public virtual Response GetApis(RequestContext context = null)
//        {
//            using var scope = ClientDiagnostics.CreateScope("ApiClient.GetApis");
//            scope.Start();
//            try
//            {
//                using HttpMessage message = CreateGetApisRequest(context);
//                return _pipeline.ProcessMessage(message, context);
//            }
//            catch (Exception e)
//            {
//                scope.Failed(e);
//                throw;
//            }
//        }

//        /// <param name="id"> The String to use. </param>
//        /// <param name="number"> The Int32 to use. </param>
//        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
//        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
//        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
//        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
//        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
//        /// <example>
//        /// This sample shows how to call GetApiAsync with required parameters and parse the result.
//        /// <code><![CDATA[
//        /// var client = new ApiClient();
//        /// 
//        /// Response response = await client.GetApiAsync("<id>");
//        /// 
//        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
//        /// Console.WriteLine(result.ToString());
//        /// ]]></code>
//        /// This sample shows how to call GetApiAsync with all parameters, and how to parse the result.
//        /// <code><![CDATA[
//        /// var client = new ApiClient();
//        /// 
//        /// Response response = await client.GetApiAsync("<id>", 1234);
//        /// 
//        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
//        /// Console.WriteLine(result.GetProperty("id").ToString());
//        /// Console.WriteLine(result.GetProperty("name").ToString());
//        /// Console.WriteLine(result.GetProperty("createdAt").ToString());
//        /// Console.WriteLine(result.GetProperty("updatedAt").ToString());
//        /// ]]></code>
//        /// </example>
//        /// <remarks>
//        /// Below is the JSON schema for the response payload.
//        /// 
//        /// Response Body:
//        /// 
//        /// Schema for <c>GetSampleViewModel</c>:
//        /// <code>{
//        ///   id: string, # Optional.
//        ///   name: string, # Optional.
//        ///   createdAt: string (ISO 8601 Format), # Optional.
//        ///   updatedAt: string (ISO 8601 Format), # Optional.
//        /// }
//        /// </code>
//        /// 
//        /// </remarks>
//        public virtual async Task<Response> GetApiAsync(string id, int? number = null, RequestContext context = null)
//        {
//            Argument.AssertNotNullOrEmpty(id, nameof(id));

//            using var scope = ClientDiagnostics.CreateScope("ApiClient.GetApi");
//            scope.Start();
//            try
//            {
//                using HttpMessage message = CreateGetApiRequest(id, number, context);
//                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
//            }
//            catch (Exception e)
//            {
//                scope.Failed(e);
//                throw;
//            }
//        }

//        /// <param name="id"> The String to use. </param>
//        /// <param name="number"> The Int32 to use. </param>
//        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
//        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
//        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
//        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
//        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
//        /// <example>
//        /// This sample shows how to call GetApi with required parameters and parse the result.
//        /// <code><![CDATA[
//        /// var client = new ApiClient();
//        /// 
//        /// Response response = client.GetApi("<id>");
//        /// 
//        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
//        /// Console.WriteLine(result.ToString());
//        /// ]]></code>
//        /// This sample shows how to call GetApi with all parameters, and how to parse the result.
//        /// <code><![CDATA[
//        /// var client = new ApiClient();
//        /// 
//        /// Response response = client.GetApi("<id>", 1234);
//        /// 
//        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
//        /// Console.WriteLine(result.GetProperty("id").ToString());
//        /// Console.WriteLine(result.GetProperty("name").ToString());
//        /// Console.WriteLine(result.GetProperty("createdAt").ToString());
//        /// Console.WriteLine(result.GetProperty("updatedAt").ToString());
//        /// ]]></code>
//        /// </example>
//        /// <remarks>
//        /// Below is the JSON schema for the response payload.
//        /// 
//        /// Response Body:
//        /// 
//        /// Schema for <c>GetSampleViewModel</c>:
//        /// <code>{
//        ///   id: string, # Optional.
//        ///   name: string, # Optional.
//        ///   createdAt: string (ISO 8601 Format), # Optional.
//        ///   updatedAt: string (ISO 8601 Format), # Optional.
//        /// }
//        /// </code>
//        /// 
//        /// </remarks>
//        public virtual Response GetApi(string id, int? number = null, RequestContext context = null)
//        {
//            Argument.AssertNotNullOrEmpty(id, nameof(id));

//            using var scope = ClientDiagnostics.CreateScope("ApiClient.GetApi");
//            scope.Start();
//            try
//            {
//                using HttpMessage message = CreateGetApiRequest(id, number, context);
//                return _pipeline.ProcessMessage(message, context);
//            }
//            catch (Exception e)
//            {
//                scope.Failed(e);
//                throw;
//            }
//        }

//        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
//        /// <param name="contentType"> Body Parameter content-type. Allowed values: &quot;application/*+json&quot; | &quot;application/json&quot; | &quot;text/json&quot;. </param>
//        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
//        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
//        /// <returns> The response returned from the service. </returns>
//        /// <example>
//        /// This sample shows how to call UpsertAsync with required parameters.
//        /// <code><![CDATA[
//        /// var client = new ApiClient();
//        /// 
//        /// var data = new {};
//        /// 
//        /// Response response = await client.UpsertAsync(RequestContent.Create(data), ContentType.ApplicationOctetStream);
//        /// Console.WriteLine(response.Status);
//        /// ]]></code>
//        /// This sample shows how to call UpsertAsync with all parameters and request content.
//        /// <code><![CDATA[
//        /// var client = new ApiClient();
//        /// 
//        /// var data = new {
//        ///     name = "<name>",
//        /// };
//        /// 
//        /// Response response = await client.UpsertAsync(RequestContent.Create(data), ContentType.ApplicationOctetStream);
//        /// Console.WriteLine(response.Status);
//        /// ]]></code>
//        /// </example>
//        /// <remarks>
//        /// Below is the JSON schema for the request payload.
//        /// 
//        /// Request Body:
//        /// 
//        /// Schema for <c>CreateSample</c>:
//        /// <code>{
//        ///   name: string, # Optional.
//        /// }
//        /// </code>
//        /// 
//        /// </remarks>
//        public virtual async Task<Response> UpsertAsync(RequestContent content, ContentType contentType, RequestContext context = null)
//        {
//            using var scope = ClientDiagnostics.CreateScope("ApiClient.Upsert");
//            scope.Start();
//            try
//            {
//                using HttpMessage message = CreateUpsertRequest(content, contentType, context);
//                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
//            }
//            catch (Exception e)
//            {
//                scope.Failed(e);
//                throw;
//            }
//        }

//        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
//        /// <param name="contentType"> Body Parameter content-type. Allowed values: &quot;application/*+json&quot; | &quot;application/json&quot; | &quot;text/json&quot;. </param>
//        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
//        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
//        /// <returns> The response returned from the service. </returns>
//        /// <example>
//        /// This sample shows how to call Upsert with required parameters.
//        /// <code><![CDATA[
//        /// var client = new ApiClient();
//        /// 
//        /// var data = new {};
//        /// 
//        /// Response response = client.Upsert(RequestContent.Create(data), ContentType.ApplicationOctetStream);
//        /// Console.WriteLine(response.Status);
//        /// ]]></code>
//        /// This sample shows how to call Upsert with all parameters and request content.
//        /// <code><![CDATA[
//        /// var client = new ApiClient();
//        /// 
//        /// var data = new {
//        ///     name = "<name>",
//        /// };
//        /// 
//        /// Response response = client.Upsert(RequestContent.Create(data), ContentType.ApplicationOctetStream);
//        /// Console.WriteLine(response.Status);
//        /// ]]></code>
//        /// </example>
//        /// <remarks>
//        /// Below is the JSON schema for the request payload.
//        /// 
//        /// Request Body:
//        /// 
//        /// Schema for <c>CreateSample</c>:
//        /// <code>{
//        ///   name: string, # Optional.
//        /// }
//        /// </code>
//        /// 
//        /// </remarks>
//        public virtual Response Upsert(RequestContent content, ContentType contentType, RequestContext context = null)
//        {
//            using var scope = ClientDiagnostics.CreateScope("ApiClient.Upsert");
//            scope.Start();
//            try
//            {
//                using HttpMessage message = CreateUpsertRequest(content, contentType, context);
//                return _pipeline.ProcessMessage(message, context);
//            }
//            catch (Exception e)
//            {
//                scope.Failed(e);
//                throw;
//            }
//        }

//        internal HttpMessage CreateGetApisRequest(RequestContext context)
//        {
//            var message = _pipeline.CreateMessage(context, ResponseClassifier200500);
//            var request = message.Request;
//            request.Method = RequestMethod.Get;
//            var uri = new RawRequestUriBuilder();
//            uri.Reset(_endpoint);
//            uri.AppendPath("/api/v1/Sample/list", false);
//            request.Uri = uri;
//            request.Headers.Add("Accept", "application/json, text/json");
//            return message;
//        }

//        internal HttpMessage CreateGetApiRequest(string id, int? number, RequestContext context)
//        {
//            var message = _pipeline.CreateMessage(context, ResponseClassifier200400500);
//            var request = message.Request;
//            request.Method = RequestMethod.Get;
//            var uri = new RawRequestUriBuilder();
//            uri.Reset(_endpoint);
//            uri.AppendPath("/api/v1/Sample/get/", false);
//            uri.AppendPath(id, true);
//            if (number != null)
//            {
//                uri.AppendQuery("number", number.Value, true);
//            }
//            request.Uri = uri;
//            request.Headers.Add("Accept", "application/json, text/json");
//            return message;
//        }

//        internal HttpMessage CreateUpsertRequest(RequestContent content, ContentType contentType, RequestContext context)
//        {
//            var message = _pipeline.CreateMessage(context, ResponseClassifier202400500);
//            var request = message.Request;
//            request.Method = RequestMethod.Post;
//            var uri = new RawRequestUriBuilder();
//            uri.Reset(_endpoint);
//            uri.AppendPath("/api/v1/Sample/upsert", false);
//            request.Uri = uri;
//            request.Headers.Add("Accept", "application/json, text/json");
//            request.Headers.Add("Content-Type", contentType.ToString());
//            request.Content = content;
//            return message;
//        }

//        private static ResponseClassifier _responseClassifier200500;
//        private static ResponseClassifier ResponseClassifier200500 => _responseClassifier200500 ??= new StatusCodeClassifier(stackalloc ushort[] { 200, 500 });
//        private static ResponseClassifier _responseClassifier200400500;
//        private static ResponseClassifier ResponseClassifier200400500 => _responseClassifier200400500 ??= new StatusCodeClassifier(stackalloc ushort[] { 200, 400, 500 });
//        private static ResponseClassifier _responseClassifier202400500;
//        private static ResponseClassifier ResponseClassifier202400500 => _responseClassifier202400500 ??= new StatusCodeClassifier(stackalloc ushort[] { 202, 400, 500 });
//    }
//}
