'use strict';

describe("AccountsController", function () {

    var $controllerConstructor;
    var scope;
    var mockPhoneData;
    var location;
    var httpMock;
    var phoneDataSvc;
    var q;
    var ctrl;
    var accountList = [{ accountId: 1 }];
    
    beforeEach(module('nagApp'));

    beforeEach(inject(function ($controller, $rootScope, $location, $httpBackend, phoneData, $q) {
        $controllerConstructor = $controller;
        scope = $rootScope.$new();
        location = $location;
        httpMock = $httpBackend;
        phoneDataSvc = phoneData;
        q = $q;
                
        mockPhoneData = sinon.stub(
            {
                getAccounts: function () {}
            }
        );

        mockPhoneData.getAccounts.returns(accountList);
        ctrl = $controllerConstructor('AccountsController',
            { $scope: scope, phoneData: mockPhoneData});

    }));

    it('should set the list of accounts on the scope', function () {
        expect(scope.accounts).toBeDefined();
        expect(scope.accounts).toBe(accountList);
    });

    it('should change the path to /accounts/add when addAccount is called', function () {
        scope.addAccount();
        expect(location.path()).toBe("/accounts/add");
    });
});