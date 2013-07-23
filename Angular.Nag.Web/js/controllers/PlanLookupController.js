'use strict';

nagApp.controller('PlanLookupController',
    function PlanLookupController($scope, $routeParams, phoneData) {
        $scope.planId = $routeParams.planId;
        $scope.plan = phoneData.getPlan($routeParams.planId);
    });
