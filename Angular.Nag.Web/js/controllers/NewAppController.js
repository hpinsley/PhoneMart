'use strict';

nagApp.controller('NewAppController', function NewAppController($scope, phoneData, $http, $location) {

    $scope.cancel = function() {
        $location.path("/apps");
    };
    
    $scope.addApp = function() {

        $http({
                method: "POST",
                url: nagApp.getServicesRoot() + "/api/apps",
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
