'use strict';

nagApp.controller('AppsController',
    function AppsController($scope, phoneData, $location) {
        $scope.apps = phoneData.getApps();
        
        $scope.addApp = function() {
            $location.path("/apps/add");
        }
    });
