'use strict';

nagApp.controller('PlanUpdateController', function PlanUpdateController($scope, $routeParams, phoneData, $http, $location, $q) {

    $scope.planId = $routeParams.planId;
    $scope.plan = phoneData.getPlan($routeParams.planId, function(plan) {
        $scope.planName = plan.planName;
        $scope.monthlyCost = plan.monthlyCost;
        $scope.voiceMinutes = plan.voiceMinutes;
        $scope.dataMegabytes = plan.dataMegabytes;
    });
    
    $scope.cancel = function () {
        $location.path("/plans/" + $scope.planId);
    };

    $scope.updatePlan = function(planId) {
        $http({
            method: "PUT",
            url: nagApp.getServicesRoot() + "/api/plans/" + planId,
            data: {
                planName: $scope.planName,
                monthlyCost: $scope.monthlyCost,
                voiceMinutes: $scope.voiceMinutes,
                dataMegabytes: $scope.dataMegabytes
            }
        })
        .success(function () {
            $location.path("/plans/" + $scope.planId);
        })
        .error(function (error) {
            alert("We got error " + (error.exceptionMessage || error.message || error));
        });
    };
});
