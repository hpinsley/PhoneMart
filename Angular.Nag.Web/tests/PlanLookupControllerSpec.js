'use strict';

describe("PlanLookupController", function () {

    var $controllerConstructor;
    var scope;
    var location;
    var httpMock;
    var phoneDataSvc;
    var q;
    var mockRouteParams;
    var ctrl;
    var planId = 9;
    var plan = { planId: planId };
    
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
                        
        ctrl = $controllerConstructor('PlanLookupController',
            { $scope: scope, $routeParams: mockRouteParams});

    }));

    it('should get the planId from routeParams', function () {
        httpMock.flush();
        expect(scope.planId).toBe(planId);
    });

    it('should lookup the plan', function () {
        httpMock.flush();
        expect(angular.equals(scope.plan, plan)).toBeTruthy();
    });
});