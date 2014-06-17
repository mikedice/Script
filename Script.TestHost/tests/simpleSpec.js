var myClass = function () {
    this.color = "red";
    this.testmethod = function (v) { return v * 2; }
};

// Test myClass
describe("This is a simple test", function () {
    // variables used by the test
    var instance;

    // initialzie data needed by the test
    beforeEach(function () { instance = new myClass(); });

    // Test cases
    it("the color to be red", function () {
        expect(instance.color).toEqual("red");
    });

    it("should double the value", function() {
        expect(instance.testmethod(2)).toEqual(4);
    });
});