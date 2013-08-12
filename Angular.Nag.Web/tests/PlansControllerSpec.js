'use strict';

describe("PlansController", function () {

    var $controllerConstructor;
    var scope;
    var mockPhoneData;
    var location;
    var httpMock;
    var phoneDataSvc;
    
    beforeEach(module('nagApp'));

    beforeEach(inject(function ($controller, $rootScope, $location, $httpBackend, phoneData) {
        $controllerConstructor = $controller;
        scope = $rootScope.$new();
        location = $location;
        httpMock = $httpBackend;
        phoneDataSvc = phoneData;
        
        mockPhoneData = sinon.stub(
            { getPlans: function () {}}
        );
    }));

    it("should return obtain phone plans and set it on the scope", function() {

        var mockPlans = {};
        mockPhoneData.getPlans.returns(mockPlans);

        var ctrl = $controllerConstructor('PlansController',
            { $scope: scope, $location: location, phoneData: mockPhoneData });

        expect(scope.plans).toBe(mockPlans);
    });

    it("should return obtain phone plans using http", function () {

        var mockPlans = {};
        httpMock.when("GET", nagApp.getServicesRoot() + "/api/plans").respond(mockPlans);

        var ctrl = $controllerConstructor('PlansController',
            { $scope: scope, $location: location, phoneData: phoneDataSvc });

        expect(scope.plans).toBeDefined();
        expect(scope.plans.then).toBeDefined();
        scope.plans.then(function (plans) {
            expect(plans).toBe(mockPlans);
        });
        httpMock.flush();
    });

});