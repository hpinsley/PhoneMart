'use strict';

nagApp.controller('AppsController',
    function AppsController($scope, phoneData, $location) {
        $scope.apps = phoneData.getApps();
    });
