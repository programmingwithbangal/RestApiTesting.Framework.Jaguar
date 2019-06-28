using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using BoDi;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestApiTesting.Framework.Jaguar.Services;
using TechTalk.SpecFlow;

namespace RestApiTesting.Framework.Jaguar.Helpers
{
    [Binding]
    public sealed class InitializeHelper
    {
        private readonly IObjectContainer m_objectContainer;

        private readonly ScenarioContext m_scenarioContext;

        public ObjectContainer ObjectContainer;

        public InitializeHelper(ObjectContainer objectContainerTemp, ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            m_scenarioContext = scenarioContext;
            m_objectContainer = objectContainer;
            ObjectContainer = objectContainerTemp;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ConfigurationHelper.BuildConfiguration();
        }

        [BeforeScenario(Order = 1)]
        public void BeforeScenario()
        {
            m_objectContainer.RegisterInstanceAs<IJsonPlaceHolderService>(new Services.Impl.JsonPlaceHolderService());
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DumpScenarioContextOnFailure();
        }

        private void DumpScenarioContextOnFailure()
        {
            if (m_scenarioContext.TestError == null)
            {
                return;
            }

            var scenarioContextClone = new Dictionary<string, object>(m_scenarioContext);

            foreach (KeyValuePair<string, object> keyValuePair in scenarioContextClone.ToList())
            {
                if (keyValuePair.Value is HttpResponseMessage value)
                {
                    scenarioContextClone[keyValuePair.Key] = "\r\n\r\n----- HttpStatusCode: {" + value + "}, \r\n----- RequestMessage: {" + value.RequestMessage + "}, \r\n----- Result: {" + value.Content.ReadAsStringAsync().Result + "}";
                }
            }

            string scenarioContextOnFailureDump = JsonConvert.SerializeObject(scenarioContextClone);
            string configurationOnFailureDump = JsonConvert.SerializeObject(ConfigurationHelper.ConfigurationRoot.AsEnumerable());

            throw new Exception(string.Join(Environment.NewLine, "\r\n\r\n----- Scenario Context Content -----\r\n", scenarioContextOnFailureDump, "\r\n----- Configuration -----\r\n", configurationOnFailureDump));
        }
    }
}