var internalReporter = window.jasmine.jsApiReporter;
internalReporter.specDone = function (result) {
    console.log("jasmine completed a run");
    internalReporter.specs.push(result);
}