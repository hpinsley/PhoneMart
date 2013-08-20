'use strict';

describe("NewPlanController", function () {

    var $controllerConstructor;
    var scope;
    var location;
    var httpMock;
    var q;
    var ctrl;
    
    beforeEach(module('nagApp'));

    beforeEach(inject(function ($controller, $rootScope, $location, $httpBackend, phoneData, $q) {
        $controllerConstructor = $controller;
        scope = $rootScope.$new();
        location = $location;
        httpMock = $httpBackend;
        q = $q;
        
        ctrl = $controllerConstructor('NewPlanController',
            { $scope: scope });

    }));

    //This doesn't seem to do anything
    afterEach(function () {
        httpMock.verifyNoOutstandingExpectation();
        httpMock.verifyNoOutstandingRequest();
    });

    it('should redirect to /plans when cancel() is called', function () {
        scope.cancel();
        expect(location.path()).toBe("/plans");
    });

    it('should post when addPlan() is called and redirect to the new plan', function () {
        var planId = 3;

        httpMock.when("POST", nagApp.getServicesRoot() + "/api/plans").respond(200, planId);

        scope.addPlan();
        httpMock.flush();
        expect(location.path()).toBe("/plans/" + planId);
    });
});