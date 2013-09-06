'use strict';

describe("PhoneInstanceLookupController", function () {

    var $controllerConstructor;
    var scope;
    var location;
    var httpMock;
    var q;
    var ctrl;
    var accountId = 5;
    var phoneInstanceId = 9;
    var account = { accountId: accountId };
    var phoneInstance = {
        accountId: accountId,
        phoneInstanceId: phoneInstanceId,
        phonePlan: { planId: 11 },
        serialNumber: "SERIAL-123",
        phoneNumber: "555-3242",
    };
    phoneInstance.planId = phoneInstance.phonePlan.planId;

    var plans = [{ planId: 1 }, { planId: 2 }];

    beforeEach(module('nagApp'));

    beforeEach(inject(function ($controller, $rootScope, $location, $httpBackend, $q) {
        $controllerConstructor = $controller;
        scope = $rootScope.$new();
        location = $location;
        httpMock = $httpBackend;
        q = $q;

        httpMock.when("GET", nagApp.getServicesRoot() + "/api/plans").respond(plans);
        httpMock.when("GET", nagApp.getServicesRoot() + "/api/accounts/" + accountId).respond(account);
        httpMock.when("GET", nagApp.getServicesRoot() + "/api/accounts/" + accountId + "/phones/" + phoneInstanceId).respond(phoneInstance);

        var mockRouteParams = { accountId: accountId, phoneInstanceId: phoneInstanceId };

        ctrl = $controllerConstructor('PhoneInstanceLookupController',
            { $scope: scope, $routeParams: mockRouteParams });


    }));

    //This doesn't seem to do anything
    afterEach(function () {
        httpMock.verifyNoOutstandingExpectation();
        httpMock.verifyNoOutstandingRequest();
    });

    it('should set the accountId on the scope from the route', function () {
        httpMock.flush();
        expect(scope.accountId).toBe(accountId);
    });

    it('should set the phoneInstanceId on the scope from the route', function () {
        httpMock.flush();
        expect(scope.phoneInstanceId).toBe(phoneInstanceId);
    });

    it('should get the list of plans', function () {
        expect(scope.plans).toBeDefined();
        //scope.plans is a promise.  You need to setup the then call before the flush
        //or this code won't fire.
        scope.plans.then(function (planList) {
            expect(planList).toBeDefined();
            expect(planList).toBe(plans);
        });
        httpMock.flush();
    });
    it('should lookup the account and set it on the scope', function () {
        expect(scope.account).toBeDefined();
        httpMock.flush();
        expect(angular.equals(scope.account, account)).toBeTruthy();
    });
    it('should lookup the phoneInstance and set it on the scope', function () {
        expect(scope.phoneInstance).toBeDefined();
        httpMock.flush();
        expect(angular.equals(scope.phoneInstance, phoneInstance)).toBeTruthy();
        expect(scope.serialNumber).toBe(phoneInstance.serialNumber);
        expect(scope.phoneNumber).toBe(phoneInstance.phoneNumber);
        expect(scope.phonePlanId).toBe(phoneInstance.planId);
    });

    it('updatePhoneInstance() should PUT and redirect to the account', function () {
        httpMock.flush();
        httpMock.when("PUT", nagApp.getServicesRoot() + "/api/accounts/" + accountId + "/phones/" + phoneInstanceId).respond(200);
        scope.updatePhoneInstance(accountId, phoneInstanceId);
        httpMock.flush();
        expect(location.path()).toBe("/accounts/" + accountId);
    });

    it('deletePhoneInstance() should DELETE and redirect to the account', function () {
        httpMock.flush();
        httpMock.when("DELETE", nagApp.getServicesRoot() + "/api/accounts/" + accountId + "/phones/" + phoneInstanceId).respond(200);
        scope.deletePhoneInstance(accountId, phoneInstanceId);
        httpMock.flush();
        expect(location.path()).toBe("/accounts/" + accountId);
    });
    it('cancel() should redirect to the account', function () {
        httpMock.flush();
        scope.cancel();
        expect(location.path()).toBe("/accounts/" + accountId);
    });

});
