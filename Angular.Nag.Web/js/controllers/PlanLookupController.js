'use strict';

nagApp.controller('PlanLookupController',
    function PlanLookupController($scope, $routeParams, phoneData, $location) {
        $scope.planId = $routeParams.planId;
        $scope.plan = phoneData.getPlan($routeParams.planId);

        $scope.cancel = function () {
            redirectToPlans();
        };

        $scope.updatePlan = function (plan) {
            $location.path("/plans/" + plan.planId + "/update");
        };

        $scope.deletePlan = function (plan) {
            redirectToPlans();
        };
        
        function redirectToPlans() {
            $location.path("/plans");
        }
    });
