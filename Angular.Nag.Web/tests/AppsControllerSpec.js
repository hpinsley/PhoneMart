'use strict';

describe("AppsController", function () {

    var $controllerConstructor;
    var scope;
    var location;
    var httpMock;
    var phoneDataSvc;
    var q;
    var ctrl;
    var apps = [{ appId: 1 }, { appId: 2 }];
    
    beforeEach(module('nagApp'));

    beforeEach(inject(function ($controller, $rootScope, $location, $httpBackend, phoneData, $q) {
        $controllerConstructor = $controller;
        scope = $rootScope.$new();
        location = $location;
        httpMock = $httpBackend;
        phoneDataSvc = phoneData;
        q = $q;
                
        httpMock.when("GET", nagApp.getServicesRoot() + "/api/apps").respond(apps);

        ctrl = $controllerConstructor('AppsController',
            { $scope: scope});

    }));

    it('should set the list of apps on the scope', function () {
        expect(scope.apps).toBeDefined();
        scope.apps.then(function (appList) {
            expect(appList).toBe(apps);
        });
        httpMock.flush();
    });

    it('addApp() should redirect to /apps/add', function () {
        httpMock.flush();
        scope.addApp();
        expect(location.path()).toBe("/apps/add");
    });

});