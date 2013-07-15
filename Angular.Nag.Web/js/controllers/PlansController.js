'use strict';

nagApp.controller('PlansController',
    function PlansController($scope, phoneData) {
        $scope.plans = phoneData.getPlans();
    });
