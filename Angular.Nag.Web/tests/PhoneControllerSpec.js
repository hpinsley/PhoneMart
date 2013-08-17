'use strict';

describe("PhoneController", function () {

    var $controllerConstructor;
    var scope;
    var location;
    var httpMock;
    var phoneDataSvc;
    var q;
    var phones = [{ phoneId: 1 }, { phoneId: 2 }];
    var ctrl;
    var manufacturers = [{ manufacturerId: 1 }, { manufacturerId: 1 }];
    var plans = [{ planId: 1 }, { planId: 2 }];
    
    beforeEach(module('nagApp'));

    beforeEach(inject(function ($controller, $rootScope, $location, $httpBackend, phoneData, $q) {
        $controllerConstructor = $controller;
        scope = $rootScope.$new();
        location = $location;
        httpMock = $httpBackend;
        phoneDataSvc = phoneData;
        q = $q;
        
        httpMock.when("GET", nagApp.getServicesRoot() + "/api/phones").respond(phones);
        httpMock.when("GET", nagApp.getServicesRoot() + "/api/manufacturers").respond(manufacturers);
        httpMock.when("GET", nagApp.getServicesRoot() + "/api/plans").respond(plans);

        ctrl = $controllerConstructor('PhoneController',
            { $scope: scope});

    }));

    it("should get the list of phones", function() {
        expect(scope.phones).toBeDefined();
        scope.phones.then(function (phoneList) {
            expect(phoneList).toBe(phones);
        });
        httpMock.flush();
    });

    it("should get the list of plans", function () {
        expect(scope.plans).toBeDefined();
        scope.plans.then(function (planList) {
            expect(planList).toBe(plans);
        });
        httpMock.flush();
    });


    it("should set the current phone to the first phone in the list", function () {
        scope.phones.then(function () {
            expect(scope.currentPhone).toBeDefined();
            expect(scope.currentPhone).toBe(phones[0]);
        });
        httpMock.flush();
    });

    it("should set the manufacturers on the scope", function () {
        expect(scope.manufacturers).toBeDefined();
        httpMock.flush();
        expect(angular.equals(scope.manufacturers, manufacturers)).toBeTruthy();
    });

    describe('filters', function () {
        it("should be cleared when no manufacturer is set", function () {
            scope.selectedManufacturer = -1;
            scope.manufacturerSelected();
            expect(scope.propertiesFilter).toBeDefined();
            expect(scope.propertiesFilter).toEqual({});
        });
        it("should be set to the manufactur's id when a manufacturer is selected", function () {
            scope.selectedManufacturer = 1;
            scope.manufacturerSelected();
            expect(scope.propertiesFilter).toBeDefined();
            expect(scope.propertiesFilter).toEqual({"manufacturer.manufacturerId" : 1});
        });
    });
});