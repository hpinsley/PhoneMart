'use strict';

describe("PlansController", function () {

    var $controllerConstructor;
    var scope;
    var location;
    var httpMock;
    var phoneDataSvc;
    var ctrl;
    var plans = [{ planId: 1 }, { planId: 2 }];
    
    beforeEach(module('nagApp'));

    beforeEach(inject(function ($controller, $rootScope, $location, $httpBackend, phoneData) {
        $controllerConstructor = $controller;
        scope = $rootScope.$new();
        location = $location;
        httpMock = $httpBackend;
        phoneDataSvc = phoneData;

        httpMock.when("GET", nagApp.getServicesRoot() + "/api/plans").respond(plans);

        ctrl = $controllerConstructor('PlansController',
            { $scope: scope });
    }));

    it("should return obtain phone plans and set it on the scope", function() {
        expect(scope.plans).toBeDefined();
        scope.plans.then(function (planList) {
            expect(planList).toBe(plans);
        });
        
        httpMock.flush();
    });

    it('should change the path to /plans/add when addPlan is called', function () {
        scope.addPlan();
        expect(location.path()).toBe("/plans/add");
    });

});