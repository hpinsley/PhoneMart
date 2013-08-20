'use strict';

nagApp.controller('PlansController',
    function PlansController($scope, phoneData, $location) {
        $scope.plans = phoneData.getPlans();
       
        $scope.addPlan = function () {
            $location.path("/plans/add");
        };

    });
