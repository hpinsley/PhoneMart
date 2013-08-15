'use strict';

describe("NewPhoneInstanceController", function () {

    var $controllerConstructor;
    var scope;
    var location;
    var httpMock;
    var q;
    var ctrl;
    var accountId = 5;
    
    var phones = [{ phoneId: 1 }, { phoneId: 2 }];
    var plans = [{ planId: 1 }, { planId: 2 }];

    beforeEach(module('nagApp'));

    beforeEach(inject(function ($controller, $rootScope, $location, $httpBackend, $q) {
        $controllerConstructor = $controller;
        scope = $rootScope.$new();
        location = $location;
        httpMock = $httpBackend;
        q = $q;

        httpMock.when("GET", nagApp.getServicesRoot() + "/api/phones").respond(phones);
        httpMock.when("GET", nagApp.getServicesRoot() + "/api/plans").respond(plans);

        var mockRouteParams = { accountId: accountId };
        ctrl = $controllerConstructor('NewPhoneInstanceController',
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

    it('should get the list of phones', function () {
        expect(scope.phones).toBeDefined();
        scope.phones.then(function(phoneList) {
            expect(phoneList).toBe(phones);
        });
        httpMock.flush();
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

    it('should redirect to /accounts/:accountId when cancel() is called', function () {
        httpMock.flush();
        scope.cancel();
        expect(location.path()).toBe("/accounts/" + accountId);
    });

    it('should POST and redirect to /accounts/:accountId when addPhone() is called', function() {
        httpMock.flush();
        httpMock.when("POST", nagApp.getServicesRoot() + "/api/accounts/" + accountId + "/phones").respond(200);
        scope.addPhone(accountId);
        httpMock.flush();
        expect(location.path()).toBe("/accounts/" + accountId);
    });
});
