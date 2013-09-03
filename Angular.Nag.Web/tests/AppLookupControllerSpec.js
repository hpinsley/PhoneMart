'use strict';

describe("AppLookupController", function () {

    var $controllerConstructor;
    var scope;
    var location;
    var httpMock;
    var phoneDataSvc;
    var q;
    var mockRouteParams;
    var ctrl;
    var appId = 9;
    var app = { appId: appId };
    
    beforeEach(module('nagApp'));

    beforeEach(inject(function ($controller, $rootScope, $location, $httpBackend, phoneData, $q) {
        $controllerConstructor = $controller;
        scope = $rootScope.$new();
        location = $location;
        httpMock = $httpBackend;
        phoneDataSvc = phoneData;
        q = $q;
        mockRouteParams = { appId: appId };

        httpMock.when("GET", nagApp.getServicesRoot() + "/api/apps/" + appId).respond(app);
                        
        ctrl = $controllerConstructor('AppLookupController',
            { $scope: scope, $routeParams: mockRouteParams});

    }));

    it('should get the appId from routeParams', function () {
        httpMock.flush();
        expect(scope.appId).toBe(appId);
    });

    it('should lookup the app', function () {
        httpMock.flush();
        expect(angular.equals(scope.app, app)).toBeTruthy();
    });

    it('cancel() should redirect to /apps', function() {
        httpMock.flush();
        scope.cancel();
        expect(location.path()).toBe("/apps");
    });

    it('update() should call PUT and redirect to /apps', function () {
        httpMock.flush();
        httpMock.when("PUT", nagApp.getServicesRoot() + "/api/apps/" + appId).respond(200);
        scope.updateApp();
        httpMock.flush();
        expect(location.path()).toBe("/apps");
    });

});