'use strict';

describe("PhoneLookupController", function () {

    var $controllerConstructor;
    var scope;
    var location;
    var httpMock;
    var phoneDataSvc;
    var q;
    var mockRouteParams;
    var ctrl;
    var phoneId = 9;
    var manufacturers = [{ manufacturerId: 1 }, { manufacturerId: 2 }];
    var plans = [{ planId: 1 }, { planId: 2 }, { planId: 3 }, { planId: 4 }];
    var apps = [{ appId: 1 }, { appId: 2 }];
    var phone = {
        phoneId: phoneId,
        manufacturer: { manufacturerId: 2 },
        model: "Saturn V",
        price: 100.0,
        description: "A rocket of a phone",
        plans: [{ planId: 1 }, { planId: 3}]
    };

    beforeEach(module('nagApp'));

    beforeEach(inject(function ($controller, $rootScope, $location, $httpBackend, phoneData, $q) {
        $controllerConstructor = $controller;
        scope = $rootScope.$new();
        location = $location;
        httpMock = $httpBackend;
        phoneDataSvc = phoneData;
        q = $q;
        mockRouteParams = { phoneId: phoneId };

        httpMock.when("GET", nagApp.getServicesRoot() + "/api/manufacturers").respond(manufacturers);
        httpMock.when("GET", nagApp.getServicesRoot() + "/api/apps").respond(apps);
        httpMock.when("GET", nagApp.getServicesRoot() + "/api/plans").respond(plans);
        httpMock.when("GET", nagApp.getServicesRoot() + "/api/phones/" + phoneId).respond(phone);

        ctrl = $controllerConstructor('PhoneLookupController',
            { $scope: scope, $routeParams: mockRouteParams});

    }));

    it('should get the phoneId from routeParams', function () {
        httpMock.flush();
        expect(scope.phoneId).toBe(phoneId);
    });

    it('should get the list of manufacturers', function () {
        httpMock.flush();
        expect(angular.equals(scope.manufacturers, manufacturers)).toBeTruthy();
    });

    it('should get the list of plans', function () {
        expect(scope.plans).toBeDefined();
        scope.plans.then(function (planList) {
            expect(planList).toBe(plans);
        });
        httpMock.flush();
    });

    it('should lookup the phone', function () {
        expect(scope.phone).toBeDefined();
        scope.phone.then(function (thePhone) {
            expect(angular.equals(thePhone, phone)).toBeTruthy();
        });
        httpMock.flush();
    });

    it('should set scope variables from the phone for the UI controls', function() {
        httpMock.flush();
        expect(scope.manufacturerId).toBe(phone.manufacturer.manufacturerId);
        expect(scope.model).toBe(phone.model);
        expect(scope.description).toBe(phone.description);
        expect(scope.price).toBe(phone.price);
    });

    it('should add a chosen property with value true to any plan associated with the phone', function () {
        httpMock.flush();
        //Iterate of the plans offered with this phone
        _.each(phone.plans, function (phonePlan) {
            //Find that plan in the master plan list
            var matchingPlan = _.find(plans, function (plan) {
                return plan.planId == phonePlan.planId;
            });
            expect(matchingPlan).toBeDefined();
            expect(matchingPlan.chosen).toBeDefined();
            expect(matchingPlan.chosen).toBeTruthy();
        });
    });

    it('cancel() should redirect to /phones', function () {
        httpMock.flush();
        scope.cancel();
        expect(location.path()).toBe("/phones");
    });

    it('delete(phone) should DELETE and redirect to /phones', function () {
        httpMock.flush();
        httpMock.when("DELETE", nagApp.getServicesRoot() + "/api/phones/" + phoneId).respond(200);
        scope.delete(phone);
        httpMock.flush();
        expect(location.path()).toBe("/phones");
    });

    it('update() should PUT and redirect to /phones', function() {
        httpMock.flush();
        httpMock.when("PUT", nagApp.getServicesRoot() + "/api/phones/" + phoneId).respond(200);
        scope.updatePhone(plans, apps);
        httpMock.flush();
        expect(location.path()).toBe("/phones");
    });
});