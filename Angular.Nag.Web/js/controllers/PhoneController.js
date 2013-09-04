'use strict';

nagApp.controller('PhoneController', function PhoneController($scope, phoneData, $location, $q) {

    $scope.pleaseWait = ($scope.applicationRunning) ? false : true;
    $scope.$root.applicationRunning = true; //We only want to put up the please wait on the first load of the controller

    $scope.apps = phoneData.getApps();
    $scope.phones = phoneData.getPhones(); //this is a promise that Angular knows how to bind to
    $scope.manufacturers = phoneData.getManufacturers();
    $scope.plans = phoneData.getPlans();
    $scope.propertiesFilter = {};
    $scope.selectedPlanId = -1;
    $scope.selectedManufacturer = -1;
    $scope.selectedAppId = -1;

    
    //After the phones load, set a current phone to the first phone
    //if one is not already set.  Note that we set it on the root scope
    //but can test existence on our scope since we the scope inherits from
    //the root scope.  $scope.phones is a promise.
    
    $scope.phones.then(function(phones) {
        if (!$scope.currentPhone && phones.length > 0) {
            setCurrentPhone(phones[0]);
        }
    }, function (err) {
        alert("Error getting phones " + (err.exceptionMessage || err.message || err));
    });

    $scope.plans.then(function (planList) {
        planList.unshift({ planId: -1, planName: "(all)" });
    });

    $scope.apps.then(function(appList) {
        appList.unshift({ appId: -1, name: "(all)" });
    });
    
    $q.all([$scope.phones, $scope.plans]).then(function () {
        $scope.pleaseWait = false;
    });

    $scope.showFilters = function(show) {
        if (show) {
            $("#filterBtn").hide();
            $("#clearFilterBtn").show();
            $("#filterToggle").slideDown();
        } else {
            $("#clearFilterBtn").hide();
            $("#filterBtn").show();
            $("#filterToggle").slideUp();
            clearFilters();
        }
    };
    
    //When a new phone is selected, remember it by setting the "current phone"
    $scope.selectPhone = function (phone) {
        setCurrentPhone(phone);
    };

    //Helper function to see which of the phones to make active.  This
    //function is used in the markup like this:
    //ng-class='{active: isActive(phone, $index)}'
    
    $scope.isActive = function (phone, index) {
        //If we are filtering the list of phones and the current phone
        //would be filtered out, we obviously can't select it.
        if (currentPhoneIsFilteredOut()) {
            return (index == 0);
        }
        else {
            return phoneIsCurrent(phone);
        }
    };

    $scope.planFilter = function(phone) {
        if ($scope.selectedPlanId == -1)
            return true;
        //If there is a selected plan, only include the phone 
        //if its list of plans contains the selected one.
        var includePhone = _.any(phone.plans,
            function (plan) {
                return (plan.planId == $scope.selectedPlanId);
            });

        console.log("Plan Filtering " + phone.model + " to be " + includePhone);
        return includePhone;
    };

    $scope.appFilter = function (phone) {
        if ($scope.selectedAppId == -1)
            return true;
        //If there is a selected app, only include the phone 
        //if its list of apps contains the selected one.
        var includePhone = _.any(phone.apps,
            function (app) {
                return (app.appId == $scope.selectedAppId);
            });

        console.log("App Filtering " + phone.model + " to be " + includePhone);
        return includePhone;
    };

    //When you pass the scoped object (which is a promise) back
    //into a controller method, Angular unwraps the real object for you.

    $scope.addPhone = function () {
        $location.path("/phones/add");
    };

    $scope.manufacturerSelected = function() {
        var manufacturerId = $scope.selectedManufacturer;
        if (!manufacturerId)
            return;
  
        if (manufacturerId == -1) {
            $scope.propertiesFilter = {};
        } else {
            $scope.propertiesFilter["manufacturer.manufacturerId"] = manufacturerId;
            console.log($scope.propertiesFilter);
        }
    };

    //=================
    //Private functions
    //=================

    function clearFilters() {
        $scope.selectedPlanId = -1;
        $scope.selectedManufacturer = -1;
        $scope.selectedAppId = -1;
    };

    //Private function to set the current phone on the root scope so 
    //that we remember it as we navigate the site.
    function setCurrentPhone(phone) {
        $scope.$root.currentPhone = phone;
    };

    //See if the passed phone matches what we have in the scope as the current phone
    function phoneIsCurrent(phone) {
        return (($scope.currentPhone) && (phone.phoneId == $scope.currentPhone.phoneId));
    }

    function currentPhoneIsFilteredOut() {
        return currentPhoneDoesntMatchSelectedManufacturer() ||
            currentPhoneDoesntIncludeSelectedPlan() ||
            currentPhoneDoesntIncludeSelectedApp();
    }

    function currentPhoneDoesntIncludeSelectedPlan() {
        if ($scope.selectedPlanId == -1)
            return false;
        if (!$scope.currentPhone)
            return false;
        
        //We have a phone and a selected plan.  See if any of the phone's included
        //plans match the selected plan

        return !_.any($scope.currentPhone.plans, function (plan) {
            return (plan.planId == $scope.selectedPlanId);
        });
    }
    
    function currentPhoneDoesntIncludeSelectedApp() {
        if ($scope.selectedAppId == -1)
            return false;
        if (!$scope.currentPhone)
            return false;

        //We have a phone and a selected app.  See if any of the phone's included
        //apps match the selected plan

        return !_.any($scope.currentPhone.apps, function (app) {
            return (app.appId == $scope.selectedAppId);
        });
    }

    function currentPhoneDoesntMatchSelectedManufacturer() {
        var filteredManufacturerId = $scope.propertiesFilter["manufacturer.manufacturerId"];

        //If we are filtering by manufacturer and the current phone has 
        //a different manufacturer then it was filtered out.  

        return ((filteredManufacturerId) && $scope.currentPhone && $scope.currentPhone.manufacturer.manufacturerId != filteredManufacturerId);
    }


});
