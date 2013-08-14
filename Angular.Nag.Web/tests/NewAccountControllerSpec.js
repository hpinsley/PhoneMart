'use strict';

describe("NewAccountController", function () {

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
        
        ctrl = $controllerConstructor('NewAccountController',
            { $scope: scope, $location: location});

    }));

    //This doesn't seem to do anything
    afterEach(function () {
        httpMock.verifyNoOutstandingExpectation();
        httpMock.verifyNoOutstandingRequest();
    });

    it('should redirect to /accounts when cancel() is called', function () {
        scope.cancel();
        expect(location.path()).toBe("/accounts");
    });

    it('should post when addAccount() is called and redirect to the new account', function () {
        var accountId = 3;

        httpMock.when("POST", nagApp.getServicesRoot() + "/api/accounts").respond(200, accountId);

        scope.addAccount();
        httpMock.flush();
        expect(location.path()).toBe("/accounts/" + accountId);
    });
});