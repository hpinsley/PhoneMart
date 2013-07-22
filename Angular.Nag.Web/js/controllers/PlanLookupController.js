'use strict';

nagApp.controller('PlanLookupController',
    function PlanLookupController($scope, $routeParams) {
        $scope.planId = $routeParams.planId;
    });
