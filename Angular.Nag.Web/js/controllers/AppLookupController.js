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
});
