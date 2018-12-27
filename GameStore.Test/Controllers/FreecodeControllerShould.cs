﻿using GameStore.DTOs;
using GameStore.Extention;
using GameStore.Test.ResponseModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace GameStore.Test.Controllers
{
    [Collection("FreecodeE2E")]
    public  class FreecodeControllerShould : BaseController
    {
        private readonly ITestOutputHelper _output;
      
        public FreecodeControllerShould(ITestOutputHelper output) : base(49914)
        {
            _output = output;
        }
        [Fact]
        [Trait("Freecodes", "FreecodeE2E")]
        public void TestGetAllFreeCodesController()
        {
            Init(49884);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = BASE_URI;
                HttpResponseMessage result = client.GetAsync("api/freecodes").GetAwaiter().GetResult();
                var content = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Responses<FreeCodeDTOs> freeCodeResponse = JsonConvert.DeserializeObject<Responses<FreeCodeDTOs>>(content);
                Assert.Equal(HttpStatusCode.OK, result.StatusCode);
                //Assert.Equal(8, freeCodeResponse.Payload.Count);
                Assert.True(freeCodeResponse.IsSuccess);
            }

        }
        [Theory]
        [InlineData("39ACCDD9-161A-4FE0-8A10-310F8C98AD93", 49885)]
        [InlineData("8B4DDF45-3956-486B-A2F6-3FEC1B3D3048", 49886)]
        [InlineData("F5153E60-15B8-468E-97AE-A01E5188F053", 49887)]
        [InlineData("42DFEC91-42C7-49F5-B449-B4E22E895088", 49888)]
        [InlineData("EC1FB6A2-755E-4561-903C-D504845D9475", 49889)]
        [Trait("Freecodes", "FreecodeE2E")]
        public void TestGetFreeCodeByIdGameController(string gameId,int port)
        {
            Init(port);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = BASE_URI;
                HttpResponseMessage result = client.GetAsync($"api/freecodes/{gameId}").GetAwaiter().GetResult();
                var content = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Responses<FreeCodeDTOs> freeCodeResponse = JsonConvert.DeserializeObject<Responses<FreeCodeDTOs>>(content);
                Assert.Equal(HttpStatusCode.OK, result.StatusCode);
                Assert.True(freeCodeResponse.IsSuccess);
            }
        }


       

        [Theory]
        [InlineData("7a897fb7-1b25-49cc-99ae-9ad516eef7e3", 49889)]
        [InlineData("292da9f0-7d8b-4bd6-a14c-a8a955f8488d", 49890)]
        [InlineData("09d7037e-0e3c-4941-bc80-53c46497b6f3", 49891)]
        [InlineData("b9ed38a3-915f-40c5-a5bc-4ca2b930d111", 49892)]

        [Trait("Freecodes", "FreecodeE2E")]
        public void TestPostNewFreeCodeController(string id,int port)
        {
            Init(port);

            SavedFreeCodeDTOs savedFreeCodeDTOsDemo = new SavedFreeCodeDTOs()
            {
                Code = (Guid.NewGuid()).ToString(),
                GameId = id.ToGuid()
            };
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = BASE_URI;
                HttpResponseMessage result = client.PostAsJsonAsync($"/api/FreeCodes", savedFreeCodeDTOsDemo).GetAwaiter().GetResult();
                var content = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Response<string> freeCodeResponse = JsonConvert.DeserializeObject<Response<string>>(content);
                Assert.Equal(HttpStatusCode.OK, result.StatusCode);
                Assert.True(freeCodeResponse.IsSuccess);
            }
        }

      
    }
}
