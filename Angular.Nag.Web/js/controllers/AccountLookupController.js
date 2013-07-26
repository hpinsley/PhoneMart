'use strict';

nagApp.controller('AccountLookupController',
    function AccountLookupController($scope, $routeParams, phoneData, $location) {
        $scope.accountId = $routeParams.accountId;
        $scope.account = phoneData.getAccount($routeParams.accountId);

        $scope.addPhone = function () {
            var path = "/accounts/" + $routeParams.accountId + "/phones/add";
            console.log(path);
            $location.path(path);
        };
    });
