'use strict';

describe("AccountLookupController", function () {

    var $controllerConstructor;
    var scope;
    var mockPhoneData;
    var location;
    var httpMock;
    var phoneDataSvc;
    var q;
    var mockRouteParams;
    var ctrl;
    
    beforeEach(module('nagApp'));

    beforeEach(inject(function ($controller, $rootScope, $location, $httpBackend, phoneData, $q) {
        $controllerConstructor = $controller;
        scope = $rootScope.$new();
        location = $location;
        httpMock = $httpBackend;
        phoneDataSvc = phoneData;
        q = $q;
        mockRouteParams = { accountId: 1 };
                
        mockPhoneData = sinon.stub(
            {
                getAccount: function () {}
            }
        );

        mockPhoneData.getAccount.returns({ accountId: 1 });
        
        ctrl = $controllerConstructor('AccountLookupController',
            { $scope: scope, $location: location, phoneData: mockPhoneData,  $routeParams: mockRouteParams});

    }));

    it('should set the account id on the scope', function () {
        expect(scope.accountId).toBeDefined();
        expect(scope.accountId).toBe(1);
    });

    it('should lookup the account and set it on the scope', function () {
        expect(scope.account).toBeDefined();
        expect(scope.account.accountId).toBe(1);
    });

    it('should set the initial mode to SHOW', function () {
        expect(scope.mode).toBe("SHOW");
    });

    it('should set the variables bound to the controls when editAccount is called', function () {
        var account = { accountHolder: { fullName: "Pinsley", contactPhoneNumber: '123', emailAddress: 'hpinsley@gmail.com' } };
        scope.editAccount(account);

        expect(scope.auFullName).toBe(account.accountHolder.fullName);
        expect(scope.auContactPhoneNumber).toBe(account.accountHolder.contactPhoneNumber);
        expect(scope.auEmailAddress).toBe(account.accountHolder.emailAddress);
        expect(scope.mode).toBe("EDIT");

    });

    it ('should make an http PUT call when updateAccount is called and return mode to SHOW', function () {
        var accountId = 1;
        httpMock.when("PUT", nagApp.getServicesRoot() + "/api/accounts/" + accountId).respond(undefined);
        scope.updateAccount(accountId);
        httpMock.flush();
        expect(scope.mode).toBe("SHOW");
    });

    describe('deleteAccount', function () {
        var accountId = 1;
        window.confirm = function () { return true; };

        beforeEach(function() {
            httpMock.when("DELETE", nagApp.getServicesRoot() + "/api/accounts/" + accountId).respond(undefined);
        });
        it('should make an http DELETE call', function () {
            scope.deleteAccount(accountId);
            httpMock.flush();
        });

        it('should redirect to /accounts', function () {
            scope.deleteAccount(accountId);
            httpMock.flush();
            expect(location.path()).toBe("/accounts");
        });
    });
});