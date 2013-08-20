'use strict';

nagApp.controller('NewPlanController', function NewPlanController($scope, $http, $location) {

    $scope.addPlan = function () {
        $http({
            method: "POST",
            url: nagApp.getServicesRoot() + "/api/plans",
            data: {
                planName: $scope.planName,
                monthlyCost: $scope.monthlyCost,
                voiceMinutes: $scope.voiceMinutes,
                dataMegabytes: $scope.dataMegabytes
            }
        })
        .success(function (planId) {
            $location.path("/plans/" + planId);
        })
        .error(function (error) {
            alert("We got error " + (error.exceptionMessage || error.message));
        });

    };

    $scope.cancel = function() {
        $location.path("/plans");
    };
});
