﻿'use strict';

nagApp.controller('PhoneLookupController', function PhoneLookupController($scope, $routeParams, phoneData, $http, $location, $q) {

    $scope.phoneId = $routeParams.phoneId;
    $scope.manufacturers = phoneData.getManufacturers();
    $scope.plans = phoneData.getPlans();
    $scope.phone = phoneData.getPhone($routeParams.phoneId);
    $scope.apps = phoneData.getApps();
    $scope.accessories = phoneData.getAccessories();
    
    //We need to wait until we have looked up the phone and also the
    //list of available plans.  For this we utilize the fact that both
    //are returned as promises.  The $q.all function takes an array of
    //promises and when ALL are resolve, it resolves with an array of
    //results.
    
    $q.all([$scope.phone, $scope.plans, $scope.apps, $scope.accessories])
        .then(function(results) {
            var phone = results[0];
            var plans = results[1];
            var apps = results[2];
            var accessories = results[3];

            $scope.manufacturerId = phone.manufacturer.manufacturerId;
            $scope.model = phone.model;
            $scope.description = phone.description;
            $scope.price = phone.price;

            // For each plan that this phone has, find the plan in the
            // master list of plans and set a property called chosen to 
            // true.  We bind off that property
            
            _.each(phone.plans, function (p) {
                var plan = _.find(plans, function (pp) {
                    return pp.planId == p.planId;
                });
                if (plan) {
                    plan.chosen = true;
                }
            });

            // For each app that this phone has, find the app in the
            // master list of apps and set a property called chosen to 
            // true.  We bind off that property

            _.each(phone.apps, function (phoneApp) {
                var app = _.find(apps, function (anApp) {
                    return anApp.appId == phoneApp.appId;
                });
                if (app) {
                    app.chosen = true;
                }
            });
            //Same thing for accessories
            _.each(phone.accessories, function(phoneAccessory) {
                var acc = _.find(accessories, function(anAcc) {
                    return anAcc.accessoryId === phoneAccessory.accessoryId;
                });
                if (acc) {
                    acc.chosen = true;
                }
            });
    });

    $scope.cancel = function() {
        $location.path("/phones");
    };

    $scope.delete = function(phone) {
        if (!confirm("Are you sure you want to delete " + phone.model + " and all of its account instances?"))
            return;

        $http({
            method: "DELETE",
            url: nagApp.getServicesRoot() + "/api/phones/" + phone.phoneId,
        })
        .success(function () {
            $location.path("/phones");
        })
        .error(function (error) {
            alert("We got error " + (error.exceptionMessage || error.message));
        });
    };
    
    $scope.updatePhone = function(plans, apps, accessories) {

        var chosenPlans = _.filter(plans, function(p) { return p.chosen; });
        var planIds = _.map(chosenPlans, function (p) { return p.planId; });

        var chosenApps = _.filter(apps, function (a) { return a.chosen; });
        var appIds = _.map(chosenApps, function (a) { return a.appId; });

        var chosenAccessories = _.filter(accessories, function (a) { return a.chosen; });
        var accessoryIds = _.map(chosenAccessories, function(a) { return a.accessoryId; });
        
        $http({
                method: "PUT",
                url: nagApp.getServicesRoot() + "/api/phones/" + $scope.phoneId,
                data: {
                    manufacturerId: $scope.manufacturerId,
                    model: $scope.model,
                    description: $scope.description,
                    price: $scope.price,
                    planIds: planIds,
                    appIds: appIds,
                    accessoryIds: accessoryIds
                }
            })
        .success(function () {
            $location.path("/phones");
        })
        .error(function (error) {
            alert("We got error " + (error.exceptionMessage || error.message || error));
        });

    };
});
