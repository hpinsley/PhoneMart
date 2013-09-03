'use strict';

describe("NewPhoneController", function () {

    var $controllerConstructor;
    var scope;
    var location;
    var httpMock;
    var q;
    var ctrl;

    var plans = [{ planId: 1, chosen: false }, { planId: 2, chosen: true }];
    var apps = [{ appId: 1, chosen: false }, { appId: 2, chosen: true }];
    var manufacturers = [{ manufacturerId: 1 }, { manufacturerId: 2 }];

    beforeEach(module('nagApp'));

    beforeEach(inject(function ($controller, $rootScope, $location, $httpBackend, $q) {
        $controllerConstructor = $controller;
        scope = $rootScope.$new();
        location = $location;
        httpMock = $httpBackend;
        q = $q;

        httpMock.when("GET", nagApp.getServicesRoot() + "/api/plans").respond(plans);
        httpMock.when("GET", nagApp.getServicesRoot() + "/api/manufacturers").respond(manufacturers);
        httpMock.when("GET", nagApp.getServicesRoot() + "/api/apps").respond(apps);

        ctrl = $controllerConstructor('NewPhoneController',
            { $scope: scope });


    }));

    //This doesn't seem to do anything
    afterEach(function () {
        httpMock.verifyNoOutstandingExpectation();
        httpMock.verifyNoOutstandingRequest();
    });

    it('should get the list of plans', function () {
        //scope.plans is a promise.  You need to setup the then call before the flush
        //or this code won't fire.
        scope.plans.then(function (scopePlans) {
            expect(scopePlans).toBeDefined();
            expect(scopePlans).toBe(plans);
        });
        httpMock.flush();
    });

    it('should get the list of manufacturers', function () {
        httpMock.flush();
        //Need to use angular.equals when comparing the return of a resource
        expect(angular.equals(scope.manufacturers, manufacturers)).toBeTruthy();
    });

    it('cancel() should redirect to /phones', function () {
        httpMock.flush();
        scope.cancel();
        expect(location.path()).toBe("/phones");
    });

    it ('addPhone() should POST and then redirect to /phones', function () {
        httpMock.flush();   //flush the get calls
        httpMock.when("POST", nagApp.getServicesRoot() + "/api/phones").respond(200);
        scope.addPhone(plans);
        httpMock.flush();
        expect(location.path()).toBe("/phones");
    }) ;
});