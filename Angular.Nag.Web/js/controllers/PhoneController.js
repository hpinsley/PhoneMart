'use strict';

nagApp.controller('PhoneController', function PhoneController($scope, phoneData, $location) {

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
        var filteredManufacturerId = $scope.filters["manufacturer.manufacturerId"];

        //If we are filtering by manufacturer and the current phone has 
        //a different manufacturer then it was filtered out.  

        return ((filteredManufacturerId) && $scope.currentPhone && $scope.currentPhone.manufacturer.manufacturerId != filteredManufacturerId);
    }
    
    $scope.phones = phoneData.getPhones(); //this is a promise that Angular knows how to bind to
    $scope.manufacturers = phoneData.getManufacturers();
    $scope.plans = phoneData.getPlans();
    
    $scope.filters = {};

    //After the phones load, set a current phone to the first phone
    //if one is not already set.  Note that we set it on the root scope
    //but can test existence on our scope since we the scope inherits from
    //the root scope.  $scope.phones is a promise.
    
    $scope.phones.then(function(phones) {
        if (!$scope.currentPhone && phones.length > 0) {
            setCurrentPhone(phones[0]);
        }
    });

    $scope.plans.then(function (planList) {
        planList.unshift({ planId: -1, planName: "(all)" });
    });

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
    
    //When you pass the scoped object (which is a promise) back
    //into a controller method, Angular unwraps the real object for you.

    $scope.addPhone = function () {
        $location.path("/phones/add");
    };

    $scope.planSelected = function () {
        var planId = $scope.selectedPlanId;
        if (!planId)
            return;
        console.log("You selected plan " + planId);
    };
    
    $scope.manufacturerSelected = function() {
        var manufacturerId = $scope.selectedManufacturer;
        if (!manufacturerId)
            return;
        console.log("You selected " + manufacturerId);
  
        if (manufacturerId == -1) {
            $scope.filters = {};
        } else {
            $scope.filters["manufacturer.manufacturerId"] = manufacturerId;
            console.log($scope.filters);
        }
    };


});
