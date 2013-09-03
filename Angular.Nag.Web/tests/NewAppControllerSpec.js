'use strict';

describe("NewAppController", function () {

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
        
        ctrl = $controllerConstructor('NewAppController',
            { $scope: scope });

    }));

    //This doesn't seem to do anything
    afterEach(function () {
        httpMock.verifyNoOutstandingExpectation();
        httpMock.verifyNoOutstandingRequest();
    });

    it('should redirect to /accounts when cancel() is called', function () {
        scope.cancel();
        expect(location.path()).toBe("/apps");
    });

    it('should post when addApp() is called and redirect to apps', function () {

        httpMock.when("POST", nagApp.getServicesRoot() + "/api/apps").respond(200);
        scope.addApp();
        httpMock.flush();
        expect(location.path()).toBe("/apps");
    });
});