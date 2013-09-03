'use strict';

nagApp.controller('AppLookupController', function AppLookupController($scope, $routeParams, phoneData, $http, $location) {
    $scope.appId = $routeParams.appId;
    $scope.app = phoneData.getApp($routeParams.appId,
        function(app) {
            $scope.appName = app.name;
            $scope.appDescription = app.description;
        });

    $scope.cancel = function () {
        $location.path("/apps");
    };

    $scope.updateApp = function() {
        var appId = $routeParams.appId;
        
        $http({
            method: "PUT",
            url: nagApp.getServicesRoot() + "/api/apps/" + appId,
            data: {
                name: $scope.appName,
                description: $scope.appDescription
            }
        })
        .success(function () {
            $location.path("/apps");
        })
        .error(function (error) {
            alert("We got error " + (error.exceptionMessage || error.message));
        });

    };
});
