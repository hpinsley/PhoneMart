'use strict';

describe("PlanUpdateController", function () {

    var $controllerConstructor;
    var scope;
    var location;
    var httpMock;
    var phoneDataSvc;
    var q;
    var ctrl;
    var planId = 9;
    var plan = { planId: planId, planName: 'From Outer Space' };
    var mockRouteParams;
    
    beforeEach(module('nagApp'));

    beforeEach(inject(function ($controller, $rootScope, $location, $httpBackend, phoneData, $q) {
        $controllerConstructor = $controller;
        scope = $rootScope.$new();
        location = $location;
        httpMock = $httpBackend;
        phoneDataSvc = phoneData;
        q = $q;
        
        mockRouteParams = { planId: planId };

        httpMock.when("GET", nagApp.getServicesRoot() + "/api/plans/" + planId).respond(plan);

        ctrl = $controllerConstructor('PlanUpdateController',
            { $scope: scope, $routeParams: mockRouteParams});

    }));

    it("should get the planId from the route", function () {
        httpMock.flush();
        expect(scope.planId).toBe(mockRouteParams.planId);
    });

    it("should lookup the plan", function () {
        httpMock.flush();
        expect(angular.equals(scope.plan, plan)).toBeTruthy();
    });

    it("cancel should redirect to /plans/:planId", function () {
        httpMock.flush();
        scope.cancel();
        expect(location.path()).toBe("/plans/" + planId);
    });

    it("updatePlan should PUT and redirect to /plans/:planId", function () {
        httpMock.flush();
        httpMock.when("PUT", nagApp.getServicesRoot() + "/api/plans/" + planId).respond(200);
        scope.updatePlan(planId);
        httpMock.flush();
        expect(location.path()).toBe("/plans/" + planId);
    });
});