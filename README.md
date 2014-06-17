Script
======
The Script project is an experimental test framework. I am developing this framework as a way to intersect modern javascript testing technologies with Microsoft MSTest infrastructure. I believe this merge will allow an efficient way to unit test Javascript code in the context of the MSTest unit testing framework

The design works like this:
MSTest runs and launches a unit test
This framework is called from C# unit test code. 
The framework launches an OWIN self-hosted HTTP endpoint on localhost
The self-hosted HTTP endpoint hosts an MVC WebAPI controller and a static file server
The framework then launches a browser pointed at the SpecRunner.html file
The SpecRunner.html file runs javascript tests using Jasmine 2.0
The Jasmine 2.0 boot.js file has been modified. In this file the JsApiReporter has been overridden with a custom override
THe custom reporter calls the webapi endpoint with test status
When all tests have been run the framework shuts down the hosted endpoint and the browser it launched.
Test results are collected and verified using MSTest API (mainly 'Assert*" api)

