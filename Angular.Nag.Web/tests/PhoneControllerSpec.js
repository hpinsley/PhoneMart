'use strict';

describe("PhoneController", function () {

    var $controllerConstructor;
    var scope;
    var mockPhoneData;
    var location;
    var httpMock;
    var phoneDataSvc;
    var q;
    var mockPhones;
    var deferredPhones;
    var phonePromise;
    var ctrl;
    var mockManufacturers;
    
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
                getPhones: function () { },
                getManufacturers: function() {
                }
            }
        );

        mockPhones = {};
        deferredPhones = q.defer();
        deferredPhones.resolve(mockPhones);
        phonePromise = deferredPhones.promise;
        mockPhoneData.getPhones.returns(phonePromise);

        mockManufacturers = {};
        mockPhoneData.getManufacturers.returns(mockManufacturers);

        ctrl = $controllerConstructor('PhoneController',
            { $scope: scope, $location: location, phoneData: mockPhoneData });

    }));

    it("should return a promise for phones", function() {
        expect(scope.phones).toBe(phonePromise);
    });

    it("should set the manufacturers on the scope", function () {
        expect(scope.manufacturers).toBeDefined();
        expect(scope.manufacturers).toBe(mockManufacturers);
    }); 
});