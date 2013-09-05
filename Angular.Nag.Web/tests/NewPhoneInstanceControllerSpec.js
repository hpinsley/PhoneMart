'use strict';

describe("NewPhoneInstanceController", function () {

    var $controllerConstructor;
    var scope;
    var location;
    var httpMock;
    var q;
    var ctrl;
    var accountId = 5;

    var account = { accountId: accountId };
    var phones = [{ phoneId: 1, plans: [ { planId: 1} ] }, { phoneId: 2, plans: [ { planId: 1}] }];

    beforeEach(module('nagApp'));

    beforeEach(inject(function ($controller, $rootScope, $location, $httpBackend, $q) {
        $controllerConstructor = $controller;
        scope = $rootScope.$new();
        location = $location;
        httpMock = $httpBackend;
        q = $q;

        httpMock.when("GET", nagApp.getServicesRoot() + "/api/phones").respond(phones);
        httpMock.when("GET", nagApp.getServicesRoot() + "/api/accounts/" + accountId).respond(account);

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

    it('should redirect to /accounts/:accountId when cancel() is called', function () {
        httpMock.flush();
        scope.cancel();
        expect(location.path()).toBe("/accounts/" + accountId);
    });

    it('should POST and redirect to /accounts/:accountId when addPhone() is called', function() {
        httpMock.flush();
        httpMock.when("POST", nagApp.getServicesRoot() + "/api/accounts/" + accountId + "/phones").respond(200);

        scope.selectedPhone = phones[0];
        scope.selectedPlan = phones[0].plans[0];
        
        scope.addPhone(accountId);
        httpMock.flush();
        expect(location.path()).toBe("/accounts/" + accountId);
    });
});
