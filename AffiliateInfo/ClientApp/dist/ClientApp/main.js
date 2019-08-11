(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ "./$$_lazy_route_resource lazy recursive":
/*!******************************************************!*\
  !*** ./$$_lazy_route_resource lazy namespace object ***!
  \******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error("Cannot find module '" + req + "'");
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "./$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/app.component.html":
/*!**************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/app.component.html ***!
  \**************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n  <div class=\"container mat-elevation-z2\" style=\"padding-bottom: 25px;border-radius: 8px; background-color: white;\">\n    <router-outlet></router-outlet>\n  </div>\n"

/***/ }),

/***/ "./node_modules/raw-loader/index.js!./src/app/home/home.component.html":
/*!********************************************************************!*\
  !*** ./node_modules/raw-loader!./src/app/home/home.component.html ***!
  \********************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<h4 class=\"containerTitle\">\r\n  Additional Entities\r\n</h4>\r\n<div class=\"row noPrint\">\r\n  <div class=\"col-12\">\r\n    <button class=\"btn btn-success float-right\" type=\"button\" (click)=\"onCloseClick()\">Save & Close</button>\r\n  </div>\r\n</div>\r\n<form [formGroup]=\"form\" (keydown.enter)=\"$event.preventDefault()\" (submit)=\"submitForm()\">\r\n  <ng-container>\r\n    <div class=\"row\" style=\"margin-top: 15px;\" formArrayName=\"corpOwners\">\r\n      <div class=\"col-12\">\r\n        <h5>Please provide the ownership of the Corporation</h5>\r\n        <table mat-table [dataSource]=\"dataSourceCorpOwner\" style=\"width: 100%;\" class=\"mat-elevation-z2\">\r\n          <ng-container matColumnDef=\"actions\">\r\n            <th mat-header-cell *matHeaderCellDef style=\"font-size: 0.9em; font-weight: bold;\" class=\"\">\r\n              <button mat-icon-button type=\"button\" class=\"text-success float-right noPrint\" color=\"primary\"\r\n                      (click)=\"addCorpOwners()\">\r\n                <mat-icon>add</mat-icon>\r\n              </button>\r\n            </th>\r\n            <td mat-cell *matCellDef=\"let element; let i = index\">\r\n              <button mat-icon-button class=\"text-danger float-right noPrint\" type=\"button\" color=\"primary\"\r\n                      (click)=\"removeCorpOwners(i)\" *ngIf=\"dataSourceCorpOwner.data.length>1\">\r\n                <mat-icon>delete</mat-icon>\r\n              </button>\r\n            </td>\r\n          </ng-container>\r\n          <ng-container matColumnDef=\"nameOfCorp\">\r\n            <th mat-header-cell *matHeaderCellDef style=\"font-size: 0.9em; font-weight: bold;\"> Name of the Corporation Owners </th>\r\n            <td mat-cell *matCellDef=\"let element; let i = index\">\r\n              <div [formGroupName]=\"i\">\r\n                <input type=\"text\" formControlName=\"corpOwnerName\" class=\"noBorder\"\r\n                       #corpOwnerNameField (keydown.enter)=\"checkIfAddNewCorpOwner(i)\"\r\n                       placeholder=\" Enter Owner's Name\"\r\n                       [class.invalid]=\"form.controls.corpOwners['controls'][i].controls.corpOwnerName.invalid && isSubmittedForm\" />\r\n              </div>\r\n            </td>\r\n          </ng-container>\r\n          <ng-container matColumnDef=\"percentOwnership\">\r\n            <th mat-header-cell *matHeaderCellDef style=\"font-size: 0.9em; font-weight: bold;max-width: 100px; padding-left: 15px\"> % of ownership </th>\r\n            <td mat-cell *matCellDef=\"let element; let i = index\" style=\"max-width: 100px\">\r\n              <div [formGroupName]=\"i\" style=\"padding-left: 10px;\">\r\n                <input type=\"text\" formControlName=\"percentOwnership\" class=\"noBorder\"\r\n                       (keydown.enter)=\"checkIfAddNewCorpOwner(i)\"\r\n                       placeholder=\" % of ownership \" OnlyNumeric\r\n                       [class.invalid]=\"form.controls.corpOwners['controls'][i].controls.percentOwnership.invalid && isSubmittedForm\" />\r\n              </div>\r\n            </td>\r\n          </ng-container>\r\n          <ng-container matColumnDef=\"disclaimer\" style=\"height: 15px\">\r\n            <td mat-footer-cell *matFooterCellDef style=\"padding-left: 10px\" class=\"text-danger\" floatLabel=\"never\">\r\n              Please fill all empty rows\r\n            </td>\r\n          </ng-container>\r\n          <ng-container matColumnDef=\"incorrectPercent\" style=\"height: 15px\">\r\n            <td mat-footer-cell *matFooterCellDef style=\"padding-left: 10px\" class=\"text-danger\" floatLabel=\"never\">\r\n              <span [class.text-white]=\"!form.controls.corpOwners.hasError('incorrectPercentSum')\">Total sum should be between 95.0% to 100.00%.</span>\r\n            </td>\r\n          </ng-container>\r\n          <tr mat-header-row *matHeaderRowDef=\"displayedColumns\"></tr>\r\n          <tr mat-row *matRowDef=\"let row; columns: displayedColumns;\"></tr>\r\n          <tr mat-footer-row *matFooterRowDef=\"['disclaimer', 'incorrectPercent']\"\r\n              [class.no-display]=\"form.controls.corpOwners.valid\"></tr>\r\n        </table>\r\n      </div>\r\n    </div>\r\n\r\n    <div formArrayName=\"aditionalEntities\" style=\"margin-top: 20px;\" class=\"pbPage\">\r\n      <mat-accordion [multi]=\"true\">\r\n        <mat-expansion-panel *ngFor=\"let entity of form.controls.aditionalEntities.controls; let i = index;\" [expanded]=\"entity.value.isExpanded\" hideToggle\r\n                             (opened)=\"setIsExpanded(i,true)\" (closed)=\"setIsExpanded(i,false)\" style=\"margin-top: 5px;\">\r\n          <mat-expansion-panel-header style=\"background-color: rgba(238, 238, 238, 0.5); border-radius: 0\">\r\n            <mat-panel-title [matTooltip]=\"entity.value.isExpanded? 'Collapse': 'Expand'\"\r\n                             matTooltipClass=\"font-2x\" matTooltipPosition=\"above\">\r\n              <h5 style=\"width: 100%; margin-top: 8px;\">\r\n                Additional Entity {{i+1}}\r\n                <mat-icon class=\"float-right text-danger noPrint\" style=\"cursor: pointer;\" *ngIf=\"form.controls.aditionalEntities.controls.length!=1\"\r\n                          (click)=\"removeAditionalEntity(i)\">cancel</mat-icon>\r\n                <mat-icon class=\"float-right text-primary noPrint\" *ngIf=\"entity.controls.isExpanded.value\" style=\"cursor: pointer;\">indeterminate_check_box</mat-icon>\r\n                <mat-icon class=\"float-right text-primary noPrint\" *ngIf=\"!entity.controls.isExpanded.value\" style=\"cursor: pointer;\">add_box</mat-icon>\r\n              </h5>\r\n            </mat-panel-title>\r\n          </mat-expansion-panel-header>\r\n          <div [formGroupName]=\"i\">\r\n            <div class=\"row\">\r\n              <div class=\"col-12\">\r\n              </div>\r\n            </div>\r\n            <div class=\"row\">\r\n              <div class=\"col-md-8\">\r\n                <mat-form-field class=\"full-width\">\r\n                  <input matInput placeholder=\"Legal Name\" formControlName=\"legalName\" type=\"text\" required>\r\n                  <mat-error *ngIf=\"entity.controls.legalName.hasError('required')\">\r\n                    Legal Name is <strong>required</strong>\r\n                  </mat-error>\r\n                </mat-form-field>\r\n              </div>\r\n              <div class=\"col-md-4\">\r\n                <mat-form-field class=\"full-width\">\r\n                  <input matInput placeholder=\"Zip Code\" formControlName=\"zipCode\" type=\"text\" required>\r\n                  <mat-error *ngIf=\"entity.controls.zipCode.hasError('required')\">\r\n                    Zip Code is <strong>required</strong>\r\n                  </mat-error>\r\n                </mat-form-field>\r\n              </div>\r\n              <div class=\"col-12\" style=\"margin-top: 10px;\">\r\n                <mat-form-field class=\"full-width\">\r\n                  <mat-chip-list #chipList formControlName=\"dba\">\r\n                    <mat-chip *ngFor=\"let dbaEl of entity.value.dba\" (removed)=\"removeDBA(dbaEl,i)\" [removable]=\"true\">\r\n                      {{dbaEl}}\r\n                      <mat-icon matChipRemove class=\"noPrint\">cancel</mat-icon>\r\n                    </mat-chip>\r\n                    <input placeholder=\"Enter each DBA name separated by semi-colon\"\r\n                           [matChipInputFor]=\"chipList\"\r\n                           [matChipInputSeparatorKeyCodes]=\"separatorKeysCodes\"\r\n                           [matChipInputAddOnBlur]=\"true\"\r\n                           (matChipInputTokenEnd)=\"addDBA($event, i)\">\r\n                  </mat-chip-list>\r\n                </mat-form-field>\r\n              </div>\r\n            </div>\r\n            <div class=\"row\" formArrayName=\"AditEntcorpOwners\">\r\n              <div class=\"col-12\" style=\"margin-top: 20px;\">\r\n                <table mat-table [dataSource]=\"dataSourceAditionalEntArr[i]\" style=\"width: 100%\" class=\"mat-elevation-z2\">\r\n                  <ng-container matColumnDef=\"actions\">\r\n                    <th mat-header-cell *matHeaderCellDef style=\"font-size: 1em; font-weight: bold;\">\r\n                      <button mat-icon-button type=\"button\" class=\"text-success float-right noPrint\"\r\n                              color=\"primary\" (click)=\"addNewAditionalEntRow(i)\">\r\n                        <mat-icon>add</mat-icon>\r\n                      </button>\r\n                    </th>\r\n                    <td mat-cell *matCellDef=\"let element; let j = index\">\r\n                      <button mat-icon-button class=\"text-danger float-right noPrint\" *ngIf=\"dataSourceAditionalEntArr[i].data.length>1\" type=\"button\"\r\n                              color=\"primary\" (click)=\"deleteAditionalEntRow(i,j)\">\r\n                        <mat-icon>delete</mat-icon>\r\n                      </button>\r\n                    </td>\r\n                  </ng-container>\r\n                  <ng-container matColumnDef=\"nameOfCorp\">\r\n                    <th mat-header-cell *matHeaderCellDef style=\"font-size: 1em; font-weight: bold;\"> Name(s) of the Additional Entity’s Owner(s) </th>\r\n                    <td mat-cell *matCellDef=\"let element; let j = index\">\r\n                      <div [formGroupName]=\"j\">\r\n                        <input type=\"text\" formControlName=\"corpOwnerName\" class=\"noBorder\"\r\n                               placeholder=\" Enter Owner's Name\" #corpOwnerEntityNameField\r\n                               id={{i}}\r\n                               [class.invalid]=\"form.controls.aditionalEntities['controls'][i].controls.AditEntcorpOwners.controls[j].controls.corpOwnerName.invalid && isSubmittedForm\"\r\n                               (keydown.enter)=\"checkIfAddNewAditionalEntiyRow(i,j)\" />\r\n                      </div>\r\n                    </td>\r\n                  </ng-container>\r\n                  <ng-container matColumnDef=\"percentOwnership\">\r\n                    <th mat-header-cell *matHeaderCellDef style=\"font-size: 0.9em; font-weight: bold;max-width: 100px; padding-left: 15px\"> % of ownership </th>\r\n                    <td mat-cell *matCellDef=\"let element; let j = index\" style=\"max-width: 100px\">\r\n                      <div [formGroupName]=\"j\">\r\n                        <input type=\"text\" class=\"noBorder\" formControlName=\"percentOwnership\" style=\"padding-left: 15px;\"\r\n                               placeholder=\" % of ownership \" OnlyNumeric\r\n                               [class.invalid]=\"form.controls.aditionalEntities['controls'][i].controls.AditEntcorpOwners.controls[j].controls.percentOwnership.invalid && isSubmittedForm\"\r\n                               (keydown.enter)=\"checkIfAddNewAditionalEntiyRow(i,j)\" />\r\n                      </div>\r\n                    </td>\r\n                  </ng-container>\r\n                  <ng-container matColumnDef=\"disclaimer\" style=\"height: 15px\">\r\n                    <td mat-footer-cell *matFooterCellDef style=\"padding-left: 10px\" class=\"text-danger\">\r\n                      <span [class.text-white]=\"entity.controls.AditEntcorpOwners.valid\">Please fill all empty rows</span>\r\n                    </td>\r\n                  </ng-container>\r\n                  <ng-container matColumnDef=\"incorrectPercent\" style=\"height: 15px\">\r\n                    <td mat-footer-cell *matFooterCellDef style=\"padding-left: 10px\" class=\"text-danger\" floatLabel=\"never\">\r\n                      <span [class.text-white]=\"!entity.controls.AditEntcorpOwners.hasError('incorrectPercentSum')\">Total sum should be between 95.0% to 100.00%.</span>\r\n                    </td>\r\n                  </ng-container>\r\n                  <tr mat-header-row *matHeaderRowDef=\"displayedColumns\"></tr>\r\n                  <tr mat-row *matRowDef=\"let row; columns: displayedColumns;\"></tr>\r\n                  <tr mat-footer-row *matFooterRowDef=\"['disclaimer', 'incorrectPercent']\" [class.no-display]=\"entity.controls.AditEntcorpOwners.valid \"></tr>\r\n                </table>\r\n              </div>\r\n            </div>\r\n          </div>\r\n        </mat-expansion-panel>\r\n      </mat-accordion>\r\n    </div>\r\n  </ng-container>\r\n\r\n  <div class=\"row noPrint\" style=\"margin-top: 30px;\">\r\n    <div class=\"col-12\">\r\n\r\n      <button class=\"btn btn-success float-right\" type=\"button\" (click)=\"onCloseClick()\">Save & Close</button>\r\n      <button class=\"btn btn-primary float-right\" style=\"margin-right: 10px;\" type=\"button\" (click)=\"addAditionalEntity()\" [disabled]=\"AdditionalEnt.length>=30\">\r\n        Add Entity\r\n      </button>\r\n    </div>\r\n  </div>\r\n</form>\r\n\r\n<!--<p>\r\n  {{//values.corpOwner[0].ownerName}}\r\n</p>-->\r\n"

/***/ }),

/***/ "./src/app/app-routing.module.ts":
/*!***************************************!*\
  !*** ./src/app/app-routing.module.ts ***!
  \***************************************/
/*! exports provided: AppRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppRoutingModule", function() { return AppRoutingModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm2015/router.js");
/* harmony import */ var _home_home_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./home/home.component */ "./src/app/home/home.component.ts");




const routes = [
    { path: 'home', component: _home_home_component__WEBPACK_IMPORTED_MODULE_3__["HomeComponent"] },
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: '**', redirectTo: '/home' }
];
let AppRoutingModule = class AppRoutingModule {
};
AppRoutingModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
        imports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"].forRoot(routes)],
        exports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"]]
    })
], AppRoutingModule);



/***/ }),

/***/ "./src/app/app.component.scss":
/*!************************************!*\
  !*** ./src/app/app.component.scss ***!
  \************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".containerTitle {\n  margin-bottom: 25px;\n  margin-top: 50px;\n  /* padding-top: 30px; */\n  background-color: #c2c2de;\n  text-align: center;\n  padding: 20px;\n  margin-left: -15px;\n  margin-right: -15px;\n  border-radius: 8px 8px 0 0;\n}\n\n@media (max-width: 767.98px) {\n  .container {\n    padding-left: 0;\n    margin-left: 0;\n    padding-right: 0;\n    margin-right: 0;\n    width: 100%;\n    max-width: 100%;\n  }\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvQzpcXFhEUklWRVxcSVRfUHJvamVjdHNcXEVMRF9QTERcXERFVkVMT1BNRU5UXFxJbnRlcm5hbFdlYkFwcGxpY2F0aW9uXFxBZmZpbGlhdGVJbmZvXFxBZmZpbGlhdGVJbmZvXFxDbGllbnRBcHAvc3JjXFxhcHBcXGFwcC5jb21wb25lbnQuc2NzcyIsInNyYy9hcHAvYXBwLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUNBO0VBQ0UsbUJBQUE7RUFDQSxnQkFBQTtFQUNBLHVCQUFBO0VBQ0EseUJBQUE7RUFDQSxrQkFBQTtFQUNBLGFBQUE7RUFDQSxrQkFBQTtFQUNBLG1CQUFBO0VBQ0EsMEJBQUE7QUNBRjs7QURHQTtFQUNFO0lBQ0UsZUFBQTtJQUNBLGNBQUE7SUFDQSxnQkFBQTtJQUNBLGVBQUE7SUFDQSxXQUFBO0lBQ0EsZUFBQTtFQ0FGO0FBQ0YiLCJmaWxlIjoic3JjL2FwcC9hcHAuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyJcclxuLmNvbnRhaW5lclRpdGxlIHtcclxuICBtYXJnaW4tYm90dG9tOiAyNXB4O1xyXG4gIG1hcmdpbi10b3A6IDUwcHg7XHJcbiAgLyogcGFkZGluZy10b3A6IDMwcHg7ICovXHJcbiAgYmFja2dyb3VuZC1jb2xvcjogI2MyYzJkZTtcclxuICB0ZXh0LWFsaWduOiBjZW50ZXI7XHJcbiAgcGFkZGluZzogMjBweDtcclxuICBtYXJnaW4tbGVmdDogLTE1cHg7XHJcbiAgbWFyZ2luLXJpZ2h0OiAtMTVweDtcclxuICBib3JkZXItcmFkaXVzOiA4cHggOHB4IDAgMDtcclxufVxyXG5cclxuQG1lZGlhIChtYXgtd2lkdGg6IDc2Ny45OHB4KSB7XHJcbiAgLmNvbnRhaW5lciB7XHJcbiAgICBwYWRkaW5nLWxlZnQ6IDA7XHJcbiAgICBtYXJnaW4tbGVmdDogMDtcclxuICAgIHBhZGRpbmctcmlnaHQ6IDA7XHJcbiAgICBtYXJnaW4tcmlnaHQ6IDA7XHJcbiAgICB3aWR0aDogMTAwJTtcclxuICAgIG1heC13aWR0aDogMTAwJTtcclxuICB9XHJcbn1cclxuIiwiLmNvbnRhaW5lclRpdGxlIHtcbiAgbWFyZ2luLWJvdHRvbTogMjVweDtcbiAgbWFyZ2luLXRvcDogNTBweDtcbiAgLyogcGFkZGluZy10b3A6IDMwcHg7ICovXG4gIGJhY2tncm91bmQtY29sb3I6ICNjMmMyZGU7XG4gIHRleHQtYWxpZ246IGNlbnRlcjtcbiAgcGFkZGluZzogMjBweDtcbiAgbWFyZ2luLWxlZnQ6IC0xNXB4O1xuICBtYXJnaW4tcmlnaHQ6IC0xNXB4O1xuICBib3JkZXItcmFkaXVzOiA4cHggOHB4IDAgMDtcbn1cblxuQG1lZGlhIChtYXgtd2lkdGg6IDc2Ny45OHB4KSB7XG4gIC5jb250YWluZXIge1xuICAgIHBhZGRpbmctbGVmdDogMDtcbiAgICBtYXJnaW4tbGVmdDogMDtcbiAgICBwYWRkaW5nLXJpZ2h0OiAwO1xuICAgIG1hcmdpbi1yaWdodDogMDtcbiAgICB3aWR0aDogMTAwJTtcbiAgICBtYXgtd2lkdGg6IDEwMCU7XG4gIH1cbn0iXX0= */"

/***/ }),

/***/ "./src/app/app.component.ts":
/*!**********************************!*\
  !*** ./src/app/app.component.ts ***!
  \**********************************/
/*! exports provided: AppComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppComponent", function() { return AppComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");


let AppComponent = class AppComponent {
    constructor() {
        this.title = 'ProductApps';
    }
};
AppComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
        selector: 'app-root',
        template: __webpack_require__(/*! raw-loader!./app.component.html */ "./node_modules/raw-loader/index.js!./src/app/app.component.html"),
        styles: [__webpack_require__(/*! ./app.component.scss */ "./src/app/app.component.scss")]
    }),
    tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [])
], AppComponent);



/***/ }),

/***/ "./src/app/app.module.ts":
/*!*******************************!*\
  !*** ./src/app/app.module.ts ***!
  \*******************************/
/*! exports provided: AppModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppModule", function() { return AppModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/fesm2015/platform-browser.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm2015/http.js");
/* harmony import */ var _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/platform-browser/animations */ "./node_modules/@angular/platform-browser/fesm2015/animations.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm2015/forms.js");
/* harmony import */ var _app_routing_module__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./app-routing.module */ "./src/app/app-routing.module.ts");
/* harmony import */ var _app_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./app.component */ "./src/app/app.component.ts");
/* harmony import */ var _material_material_module__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./material/material.module */ "./src/app/material/material.module.ts");
/* harmony import */ var _home_home_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./home/home.component */ "./src/app/home/home.component.ts");










let AppModule = class AppModule {
};
AppModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["NgModule"])({
        declarations: [
            _app_component__WEBPACK_IMPORTED_MODULE_7__["AppComponent"],
            _home_home_component__WEBPACK_IMPORTED_MODULE_9__["HomeComponent"],
        ],
        imports: [
            _angular_platform_browser__WEBPACK_IMPORTED_MODULE_1__["BrowserModule"],
            _angular_forms__WEBPACK_IMPORTED_MODULE_5__["FormsModule"],
            _angular_forms__WEBPACK_IMPORTED_MODULE_5__["ReactiveFormsModule"],
            _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_4__["BrowserAnimationsModule"],
            _app_routing_module__WEBPACK_IMPORTED_MODULE_6__["AppRoutingModule"],
            _angular_common_http__WEBPACK_IMPORTED_MODULE_3__["HttpClientModule"],
            _material_material_module__WEBPACK_IMPORTED_MODULE_8__["MaterialModule"]
        ],
        bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_7__["AppComponent"]]
    })
], AppModule);



/***/ }),

/***/ "./src/app/common/validators/custom.validators.ts":
/*!********************************************************!*\
  !*** ./src/app/common/validators/custom.validators.ts ***!
  \********************************************************/
/*! exports provided: ValidateArrayEmpty, ValidateArray100percent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ValidateArrayEmpty", function() { return ValidateArrayEmpty; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ValidateArray100percent", function() { return ValidateArray100percent; });
function ValidateArrayEmpty(control) {
    if (control.value && control.value.length > 0) {
        return null;
    }
    return { emptyArray: true };
}
function ValidateArray100percent(control) {
    const pSum = control.value.map(a => parseFloat(a.percentOwnership) ?
        parseFloat(a.percentOwnership) : 0).reduce((a, b) => a + b);
    return (pSum >= 95.00 && pSum <= 100.0) ? null : { incorrectPercentSum: true };
}


/***/ }),

/***/ "./src/app/home/home.component.scss":
/*!******************************************!*\
  !*** ./src/app/home/home.component.scss ***!
  \******************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".example-form {\n  min-width: 150px;\n  max-width: 500px;\n  width: 100%;\n}\n\n.example-full-width {\n  width: 100%;\n}\n\n.tableDisplay {\n  max-width: 80%;\n  width: 100%;\n  padding: 10px;\n  margin: 20px;\n  border: 1px solid #808080;\n  border-radius: 5px;\n}\n\n.elemnRow {\n  border-bottom: 1px dotted #808080;\n  width: 80%;\n  padding: 1px 10px;\n  font-size: 15px;\n  height: 20px;\n}\n\ntr.mat-footer-row, tr.mat-row {\n  height: 30px;\n}\n\ntd.mat-cell:first-child, td.mat-footer-cell:first-child, th.mat-header-cell:first-child {\n  border-right: 1px solid rgba(0, 0, 0, 0.3);\n}\n\n.nospacingRow {\n  border: none;\n  padding-top: 0;\n  padding-bottom: 5px;\n  margin-top: 8px;\n  margin-bottom: 0;\n}\n\n.card-body {\n  padding-top: 3px;\n}\n\n.elementContainer {\n  padding-top: 40px;\n  padding-left: 20px;\n  padding-right: 20px;\n}\n\n.btn-NotOuline:focus {\n  outline: none;\n}\n\n@media (max-width: 767.98px) {\n  .tableDisplay {\n    max-width: 100%;\n    padding: 0;\n    margin: 3px;\n    margin-bottom: 20px;\n  }\n\n  .container {\n    padding-left: 5px !important;\n    padding-right: 5px !important;\n  }\n\n  .elementContainer {\n    padding-top: 20px;\n    padding-left: 12px;\n    padding-right: 5px;\n  }\n}\n\n@media print {\n  .mat-elevation-z2 {\n    border: 1px solid #808080 !important;\n  }\n\n  .mat-form-field-underline {\n    border-bottom: 1px solid #808080 !important;\n  }\n\n  .mat-radio-button.mat-accent.mat-radio-checked .mat-radio-outer-circle, .mat-radio-button.mat-accent .mat-radio-inner-circle {\n    background-color: black !important;\n    border: 6px solid #808080 !important;\n  }\n\n  .btn-noPrint {\n    display: none;\n  }\n}\n\ntable, table td {\n  border-collapse: separate;\n}\n\n.nextBtn {\n  padding-top: 0px;\n}\n\n.mat-iconInsideBtn {\n  position: relative !important;\n  top: 6px !important;\n}\n\n.printIcon {\n  height: 35px;\n  width: 35px;\n  float: right;\n  font-size: 27px;\n}\n\n/*.mat-chip-list-wrapper .mat-standard-chip, .mat-chip-list-wrapper input.mat-input-element {\n  margin: 4px;\n}*/\n\n.mat-standard-chip.mat-chip-with-trailing-icon {\n  padding-top: 5px !important;\n  padding-bottom: 5px !important;\n  padding-right: 6px !important;\n  padding-left: 6px !important;\n}\n\n.mat-standard-chip[_ngcontent-c9] {\n  border-radius: 10px;\n}\n\n.mat-chip.mat-standard-chip {\n  background-color: white;\n  color: rgba(75, 74, 74, 0.87);\n  border: 1px solid #6e6e6e;\n  font-weight: 700;\n}\n\n.noBorder {\n  border: none;\n  outline: none;\n  width: calc(100% - 10px );\n}\n\n.no-underline .mat-form-field-underline {\n  height: 0px !important;\n}\n\n.no-display {\n  display: none !important;\n}\n\n.mat-standard-chip {\n  border-radius: 10px;\n}\n\ntr.mat-row {\n  height: 38px;\n}\n\n.invalid {\n  border-bottom: 1px;\n  border-bottom-color: red;\n  border-bottom-style: solid;\n}\n\n.high-red {\n  border: solid 1px red;\n  padding-left: 4px;\n  padding-right: 4px;\n  border-radius: 5px;\n}\n\ntd.mat-cell:first-of-type, td.mat-footer-cell:first-of-type, th.mat-header-cell:first-of-type {\n  padding-left: 5px;\n}\n\ntd.mat-cell:last-of-type, td.mat-footer-cell:last-of-type, th.mat-header-cell:last-of-type {\n  padding-right: 5px;\n}\n\n.containerTitle {\n  margin-bottom: 25px;\n  margin-top: 50px;\n  /* padding-top: 30px; */\n  background-color: #c2c2de;\n  text-align: center;\n  padding: 20px;\n  margin-left: -15px;\n  margin-right: -15px;\n  border-radius: 8px 8px 0 0;\n}\n\n.mat-expansion-panel:not(.mat-expanded) .mat-expansion-panel-header:not([aria-disabled=true]) {\n  background: #f6f6ff;\n}\n\n.mat-expansion-panel {\n  page-break-before: always;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvaG9tZS9DOlxcWERSSVZFXFxJVF9Qcm9qZWN0c1xcRUxEX1BMRFxcREVWRUxPUE1FTlRcXEludGVybmFsV2ViQXBwbGljYXRpb25cXEFmZmlsaWF0ZUluZm9cXEFmZmlsaWF0ZUluZm9cXENsaWVudEFwcC9zcmNcXGFwcFxcaG9tZVxcaG9tZS5jb21wb25lbnQuc2NzcyIsInNyYy9hcHAvaG9tZS9ob21lLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0UsZ0JBQUE7RUFDQSxnQkFBQTtFQUNBLFdBQUE7QUNDRjs7QURFQTtFQUNFLFdBQUE7QUNDRjs7QURFQTtFQUNFLGNBQUE7RUFDQSxXQUFBO0VBQ0EsYUFBQTtFQUNBLFlBQUE7RUFDQSx5QkFBQTtFQUNBLGtCQUFBO0FDQ0Y7O0FERUE7RUFDRSxpQ0FBQTtFQUNBLFVBQUE7RUFDQSxpQkFBQTtFQUNBLGVBQUE7RUFDQSxZQUFBO0FDQ0Y7O0FERUE7RUFDRSxZQUFBO0FDQ0Y7O0FERUE7RUFDRSwwQ0FBQTtBQ0NGOztBREVBO0VBQ0UsWUFBQTtFQUNBLGNBQUE7RUFDQSxtQkFBQTtFQUNBLGVBQUE7RUFDQSxnQkFBQTtBQ0NGOztBREVBO0VBQ0UsZ0JBQUE7QUNDRjs7QURFQTtFQUNFLGlCQUFBO0VBQ0Esa0JBQUE7RUFDQSxtQkFBQTtBQ0NGOztBREVBO0VBQ0UsYUFBQTtBQ0NGOztBREVBO0VBRUU7SUFDRSxlQUFBO0lBQ0EsVUFBQTtJQUNBLFdBQUE7SUFDQSxtQkFBQTtFQ0FGOztFREdBO0lBQ0UsNEJBQUE7SUFDQSw2QkFBQTtFQ0FGOztFREdBO0lBQ0UsaUJBQUE7SUFDQSxrQkFBQTtJQUNBLGtCQUFBO0VDQUY7QUFDRjs7QURHQTtFQUVFO0lBQ0Usb0NBQUE7RUNGRjs7RURLQTtJQUNFLDJDQUFBO0VDRkY7O0VES0Y7SUFDSSxrQ0FBQTtJQUNBLG9DQUFBO0VDRkY7O0VES0E7SUFDRSxhQUFBO0VDRkY7QUFDRjs7QURLQTtFQUNFLHlCQUFBO0FDSEY7O0FETUE7RUFDRSxnQkFBQTtBQ0hGOztBRE1BO0VBQ0UsNkJBQUE7RUFDQSxtQkFBQTtBQ0hGOztBRE1BO0VBQ0UsWUFBQTtFQUNBLFdBQUE7RUFDQSxZQUFBO0VBQ0EsZUFBQTtBQ0hGOztBRFFBOztFQUFBOztBQUtBO0VBQ0UsMkJBQUE7RUFDQSw4QkFBQTtFQUNBLDZCQUFBO0VBQ0EsNEJBQUE7QUNQRjs7QURVQTtFQUNFLG1CQUFBO0FDUEY7O0FEVUE7RUFDRSx1QkFBQTtFQUNBLDZCQUFBO0VBQ0EseUJBQUE7RUFDQSxnQkFBQTtBQ1BGOztBRFlBO0VBQ0UsWUFBQTtFQUNBLGFBQUE7RUFDQSx5QkFBQTtBQ1RGOztBRGVBO0VBQ0Usc0JBQUE7QUNaRjs7QURnQkE7RUFDRSx3QkFBQTtBQ2JGOztBRGlCQTtFQUNFLG1CQUFBO0FDZEY7O0FEaUJBO0VBQ0UsWUFBQTtBQ2RGOztBRGlCQTtFQUNFLGtCQUFBO0VBQ0Esd0JBQUE7RUFDQSwwQkFBQTtBQ2RGOztBRGlCQTtFQUNFLHFCQUFBO0VBQ0EsaUJBQUE7RUFDQSxrQkFBQTtFQUNBLGtCQUFBO0FDZEY7O0FEa0JBO0VBQ0UsaUJBQUE7QUNmRjs7QURtQkE7RUFDRSxrQkFBQTtBQ2hCRjs7QURvQkE7RUFDRSxtQkFBQTtFQUNBLGdCQUFBO0VBQ0EsdUJBQUE7RUFDQSx5QkFBQTtFQUNBLGtCQUFBO0VBQ0EsYUFBQTtFQUNBLGtCQUFBO0VBQ0EsbUJBQUE7RUFDQSwwQkFBQTtBQ2pCRjs7QURxQkE7RUFDRSxtQkFBQTtBQ2xCRjs7QURzQkE7RUFDRSx5QkFBQTtBQ25CRiIsImZpbGUiOiJzcmMvYXBwL2hvbWUvaG9tZS5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIi5leGFtcGxlLWZvcm0ge1xyXG4gIG1pbi13aWR0aDogMTUwcHg7XHJcbiAgbWF4LXdpZHRoOiA1MDBweDtcclxuICB3aWR0aDogMTAwJTtcclxufVxyXG5cclxuLmV4YW1wbGUtZnVsbC13aWR0aCB7XHJcbiAgd2lkdGg6IDEwMCU7XHJcbn1cclxuXHJcbi50YWJsZURpc3BsYXkge1xyXG4gIG1heC13aWR0aDogODAlO1xyXG4gIHdpZHRoOiAxMDAlO1xyXG4gIHBhZGRpbmc6IDEwcHg7XHJcbiAgbWFyZ2luOiAyMHB4O1xyXG4gIGJvcmRlcjogMXB4IHNvbGlkICM4MDgwODA7XHJcbiAgYm9yZGVyLXJhZGl1czogNXB4O1xyXG59XHJcblxyXG4uZWxlbW5Sb3cge1xyXG4gIGJvcmRlci1ib3R0b206IDFweCBkb3R0ZWQgIzgwODA4MDtcclxuICB3aWR0aDogODAlO1xyXG4gIHBhZGRpbmc6IDFweCAxMHB4O1xyXG4gIGZvbnQtc2l6ZTogMTVweDtcclxuICBoZWlnaHQ6IDIwcHg7XHJcbn1cclxuXHJcbnRyLm1hdC1mb290ZXItcm93LCB0ci5tYXQtcm93IHtcclxuICBoZWlnaHQ6IDMwcHg7XHJcbn1cclxuXHJcbnRkLm1hdC1jZWxsOmZpcnN0LWNoaWxkLCB0ZC5tYXQtZm9vdGVyLWNlbGw6Zmlyc3QtY2hpbGQsIHRoLm1hdC1oZWFkZXItY2VsbDpmaXJzdC1jaGlsZCB7XHJcbiAgYm9yZGVyLXJpZ2h0OiAxcHggc29saWQgcmdiYSgwLDAsMCwuMzApO1xyXG59XHJcblxyXG4ubm9zcGFjaW5nUm93IHtcclxuICBib3JkZXI6IG5vbmU7XHJcbiAgcGFkZGluZy10b3A6IDA7XHJcbiAgcGFkZGluZy1ib3R0b206IDVweDtcclxuICBtYXJnaW4tdG9wOiA4cHg7XHJcbiAgbWFyZ2luLWJvdHRvbTogMDtcclxufVxyXG5cclxuLmNhcmQtYm9keSB7XHJcbiAgcGFkZGluZy10b3A6IDNweDtcclxufVxyXG5cclxuLmVsZW1lbnRDb250YWluZXIge1xyXG4gIHBhZGRpbmctdG9wOiA0MHB4O1xyXG4gIHBhZGRpbmctbGVmdDogMjBweDtcclxuICBwYWRkaW5nLXJpZ2h0OiAyMHB4O1xyXG59XHJcblxyXG4uYnRuLU5vdE91bGluZTpmb2N1cyB7XHJcbiAgb3V0bGluZTogbm9uZTtcclxufVxyXG5cclxuQG1lZGlhIChtYXgtd2lkdGg6IDc2Ny45OHB4KSB7XHJcblxyXG4gIC50YWJsZURpc3BsYXkge1xyXG4gICAgbWF4LXdpZHRoOiAxMDAlO1xyXG4gICAgcGFkZGluZzogMDtcclxuICAgIG1hcmdpbjogM3B4O1xyXG4gICAgbWFyZ2luLWJvdHRvbTogMjBweDtcclxuICB9XHJcblxyXG4gIC5jb250YWluZXIge1xyXG4gICAgcGFkZGluZy1sZWZ0OiA1cHggIWltcG9ydGFudDtcclxuICAgIHBhZGRpbmctcmlnaHQ6IDVweCAhaW1wb3J0YW50O1xyXG4gIH1cclxuXHJcbiAgLmVsZW1lbnRDb250YWluZXIge1xyXG4gICAgcGFkZGluZy10b3A6IDIwcHg7XHJcbiAgICBwYWRkaW5nLWxlZnQ6IDEycHg7XHJcbiAgICBwYWRkaW5nLXJpZ2h0OiA1cHg7XHJcbiAgfVxyXG59XHJcblxyXG5AbWVkaWEgcHJpbnQge1xyXG5cclxuICAubWF0LWVsZXZhdGlvbi16MiB7XHJcbiAgICBib3JkZXI6IDFweCBzb2xpZCAjODA4MDgwICFpbXBvcnRhbnQ7XHJcbiAgfVxyXG5cclxuICAubWF0LWZvcm0tZmllbGQtdW5kZXJsaW5lIHtcclxuICAgIGJvcmRlci1ib3R0b206IDFweCBzb2xpZCAjODA4MDgwICFpbXBvcnRhbnQ7XHJcbiAgfVxyXG5cclxuLm1hdC1yYWRpby1idXR0b24ubWF0LWFjY2VudC5tYXQtcmFkaW8tY2hlY2tlZCAubWF0LXJhZGlvLW91dGVyLWNpcmNsZSwgLm1hdC1yYWRpby1idXR0b24ubWF0LWFjY2VudCAubWF0LXJhZGlvLWlubmVyLWNpcmNsZSB7XHJcbiAgICBiYWNrZ3JvdW5kLWNvbG9yOiBibGFjayAhaW1wb3J0YW50O1xyXG4gICAgYm9yZGVyOiA2cHggc29saWQgIzgwODA4MCAhaW1wb3J0YW50O1xyXG4gIH1cclxuXHJcbiAgLmJ0bi1ub1ByaW50IHtcclxuICAgIGRpc3BsYXk6IG5vbmU7XHJcbiAgfVxyXG59XHJcblxyXG50YWJsZSwgdGFibGUgdGQge1xyXG4gIGJvcmRlci1jb2xsYXBzZTogc2VwYXJhdGU7XHJcbn1cclxuXHJcbi5uZXh0QnRuIHtcclxuICBwYWRkaW5nLXRvcDogMHB4O1xyXG59XHJcblxyXG4ubWF0LWljb25JbnNpZGVCdG4ge1xyXG4gIHBvc2l0aW9uOiByZWxhdGl2ZSAhaW1wb3J0YW50O1xyXG4gIHRvcDogNnB4ICFpbXBvcnRhbnQ7XHJcbn1cclxuXHJcbi5wcmludEljb24ge1xyXG4gIGhlaWdodDogMzVweDtcclxuICB3aWR0aDogMzVweDtcclxuICBmbG9hdDogcmlnaHQ7XHJcbiAgZm9udC1zaXplOiAyN3B4O1xyXG59XHJcblxyXG5cclxuXHJcbi8qLm1hdC1jaGlwLWxpc3Qtd3JhcHBlciAubWF0LXN0YW5kYXJkLWNoaXAsIC5tYXQtY2hpcC1saXN0LXdyYXBwZXIgaW5wdXQubWF0LWlucHV0LWVsZW1lbnQge1xuICBtYXJnaW46IDRweDtcbn0qL1xyXG5cclxuXHJcbi5tYXQtc3RhbmRhcmQtY2hpcC5tYXQtY2hpcC13aXRoLXRyYWlsaW5nLWljb24ge1xyXG4gIHBhZGRpbmctdG9wOiA1cHggIWltcG9ydGFudDtcclxuICBwYWRkaW5nLWJvdHRvbTogNXB4ICFpbXBvcnRhbnQ7XHJcbiAgcGFkZGluZy1yaWdodDogNnB4ICFpbXBvcnRhbnQ7XHJcbiAgcGFkZGluZy1sZWZ0OiA2cHggIWltcG9ydGFudDtcclxufVxyXG5cclxuLm1hdC1zdGFuZGFyZC1jaGlwW19uZ2NvbnRlbnQtYzldIHtcclxuICBib3JkZXItcmFkaXVzOiAxMHB4O1xyXG59XHJcblxyXG4ubWF0LWNoaXAubWF0LXN0YW5kYXJkLWNoaXAge1xyXG4gIGJhY2tncm91bmQtY29sb3I6IHdoaXRlO1xyXG4gIGNvbG9yOiByZ2JhKDc1LCA3NCwgNzQsIDAuODcpO1xyXG4gIGJvcmRlcjogMXB4IHNvbGlkICM2ZTZlNmU7XHJcbiAgZm9udC13ZWlnaHQ6IDcwMDtcclxufVxyXG5cclxuXHJcblxyXG4ubm9Cb3JkZXIge1xyXG4gIGJvcmRlcjogbm9uZTtcclxuICBvdXRsaW5lOiBub25lO1xyXG4gIHdpZHRoOiBjYWxjKDEwMCUgLSAxMHB4ICk7XHJcbn1cclxuXHJcblxyXG5cclxuXHJcbi5uby11bmRlcmxpbmUgLm1hdC1mb3JtLWZpZWxkLXVuZGVybGluZSB7XHJcbiAgaGVpZ2h0OiAwcHggIWltcG9ydGFudDtcclxufVxyXG5cclxuXHJcbi5uby1kaXNwbGF5IHtcclxuICBkaXNwbGF5OiBub25lICFpbXBvcnRhbnQ7XHJcbn1cclxuXHJcblxyXG4ubWF0LXN0YW5kYXJkLWNoaXAge1xyXG4gIGJvcmRlci1yYWRpdXM6IDEwcHg7XHJcbn1cclxuXHJcbnRyLm1hdC1yb3cge1xyXG4gIGhlaWdodDogMzhweDtcclxufVxyXG5cclxuLmludmFsaWQge1xyXG4gIGJvcmRlci1ib3R0b206IDFweDtcclxuICBib3JkZXItYm90dG9tLWNvbG9yOiByZWQ7XHJcbiAgYm9yZGVyLWJvdHRvbS1zdHlsZTogc29saWQ7XHJcbn1cclxuXHJcbi5oaWdoLXJlZCB7XHJcbiAgYm9yZGVyOiBzb2xpZCAxcHggcmVkO1xyXG4gIHBhZGRpbmctbGVmdDogNHB4O1xyXG4gIHBhZGRpbmctcmlnaHQ6IDRweDtcclxuICBib3JkZXItcmFkaXVzOiA1cHg7XHJcbn1cclxuXHJcblxyXG50ZC5tYXQtY2VsbDpmaXJzdC1vZi10eXBlLCB0ZC5tYXQtZm9vdGVyLWNlbGw6Zmlyc3Qtb2YtdHlwZSwgdGgubWF0LWhlYWRlci1jZWxsOmZpcnN0LW9mLXR5cGUge1xyXG4gIHBhZGRpbmctbGVmdDogNXB4O1xyXG59XHJcblxyXG5cclxudGQubWF0LWNlbGw6bGFzdC1vZi10eXBlLCB0ZC5tYXQtZm9vdGVyLWNlbGw6bGFzdC1vZi10eXBlLCB0aC5tYXQtaGVhZGVyLWNlbGw6bGFzdC1vZi10eXBlIHtcclxuICBwYWRkaW5nLXJpZ2h0OiA1cHg7XHJcbn1cclxuXHJcblxyXG4uY29udGFpbmVyVGl0bGUge1xyXG4gIG1hcmdpbi1ib3R0b206IDI1cHg7XHJcbiAgbWFyZ2luLXRvcDogNTBweDtcclxuICAvKiBwYWRkaW5nLXRvcDogMzBweDsgKi9cclxuICBiYWNrZ3JvdW5kLWNvbG9yOiAjYzJjMmRlO1xyXG4gIHRleHQtYWxpZ246IGNlbnRlcjtcclxuICBwYWRkaW5nOiAyMHB4O1xyXG4gIG1hcmdpbi1sZWZ0OiAtMTVweDtcclxuICBtYXJnaW4tcmlnaHQ6IC0xNXB4O1xyXG4gIGJvcmRlci1yYWRpdXM6IDhweCA4cHggMCAwO1xyXG59XHJcblxyXG5cclxuLm1hdC1leHBhbnNpb24tcGFuZWw6bm90KC5tYXQtZXhwYW5kZWQpIC5tYXQtZXhwYW5zaW9uLXBhbmVsLWhlYWRlcjpub3QoW2FyaWEtZGlzYWJsZWQ9dHJ1ZV0pIHtcclxuICBiYWNrZ3JvdW5kOiAjZjZmNmZmO1xyXG59XHJcblxyXG5cclxuLm1hdC1leHBhbnNpb24tcGFuZWwge1xyXG4gIHBhZ2UtYnJlYWstYmVmb3JlOiBhbHdheXNcclxufVxyXG4iLCIuZXhhbXBsZS1mb3JtIHtcbiAgbWluLXdpZHRoOiAxNTBweDtcbiAgbWF4LXdpZHRoOiA1MDBweDtcbiAgd2lkdGg6IDEwMCU7XG59XG5cbi5leGFtcGxlLWZ1bGwtd2lkdGgge1xuICB3aWR0aDogMTAwJTtcbn1cblxuLnRhYmxlRGlzcGxheSB7XG4gIG1heC13aWR0aDogODAlO1xuICB3aWR0aDogMTAwJTtcbiAgcGFkZGluZzogMTBweDtcbiAgbWFyZ2luOiAyMHB4O1xuICBib3JkZXI6IDFweCBzb2xpZCAjODA4MDgwO1xuICBib3JkZXItcmFkaXVzOiA1cHg7XG59XG5cbi5lbGVtblJvdyB7XG4gIGJvcmRlci1ib3R0b206IDFweCBkb3R0ZWQgIzgwODA4MDtcbiAgd2lkdGg6IDgwJTtcbiAgcGFkZGluZzogMXB4IDEwcHg7XG4gIGZvbnQtc2l6ZTogMTVweDtcbiAgaGVpZ2h0OiAyMHB4O1xufVxuXG50ci5tYXQtZm9vdGVyLXJvdywgdHIubWF0LXJvdyB7XG4gIGhlaWdodDogMzBweDtcbn1cblxudGQubWF0LWNlbGw6Zmlyc3QtY2hpbGQsIHRkLm1hdC1mb290ZXItY2VsbDpmaXJzdC1jaGlsZCwgdGgubWF0LWhlYWRlci1jZWxsOmZpcnN0LWNoaWxkIHtcbiAgYm9yZGVyLXJpZ2h0OiAxcHggc29saWQgcmdiYSgwLCAwLCAwLCAwLjMpO1xufVxuXG4ubm9zcGFjaW5nUm93IHtcbiAgYm9yZGVyOiBub25lO1xuICBwYWRkaW5nLXRvcDogMDtcbiAgcGFkZGluZy1ib3R0b206IDVweDtcbiAgbWFyZ2luLXRvcDogOHB4O1xuICBtYXJnaW4tYm90dG9tOiAwO1xufVxuXG4uY2FyZC1ib2R5IHtcbiAgcGFkZGluZy10b3A6IDNweDtcbn1cblxuLmVsZW1lbnRDb250YWluZXIge1xuICBwYWRkaW5nLXRvcDogNDBweDtcbiAgcGFkZGluZy1sZWZ0OiAyMHB4O1xuICBwYWRkaW5nLXJpZ2h0OiAyMHB4O1xufVxuXG4uYnRuLU5vdE91bGluZTpmb2N1cyB7XG4gIG91dGxpbmU6IG5vbmU7XG59XG5cbkBtZWRpYSAobWF4LXdpZHRoOiA3NjcuOThweCkge1xuICAudGFibGVEaXNwbGF5IHtcbiAgICBtYXgtd2lkdGg6IDEwMCU7XG4gICAgcGFkZGluZzogMDtcbiAgICBtYXJnaW46IDNweDtcbiAgICBtYXJnaW4tYm90dG9tOiAyMHB4O1xuICB9XG5cbiAgLmNvbnRhaW5lciB7XG4gICAgcGFkZGluZy1sZWZ0OiA1cHggIWltcG9ydGFudDtcbiAgICBwYWRkaW5nLXJpZ2h0OiA1cHggIWltcG9ydGFudDtcbiAgfVxuXG4gIC5lbGVtZW50Q29udGFpbmVyIHtcbiAgICBwYWRkaW5nLXRvcDogMjBweDtcbiAgICBwYWRkaW5nLWxlZnQ6IDEycHg7XG4gICAgcGFkZGluZy1yaWdodDogNXB4O1xuICB9XG59XG5AbWVkaWEgcHJpbnQge1xuICAubWF0LWVsZXZhdGlvbi16MiB7XG4gICAgYm9yZGVyOiAxcHggc29saWQgIzgwODA4MCAhaW1wb3J0YW50O1xuICB9XG5cbiAgLm1hdC1mb3JtLWZpZWxkLXVuZGVybGluZSB7XG4gICAgYm9yZGVyLWJvdHRvbTogMXB4IHNvbGlkICM4MDgwODAgIWltcG9ydGFudDtcbiAgfVxuXG4gIC5tYXQtcmFkaW8tYnV0dG9uLm1hdC1hY2NlbnQubWF0LXJhZGlvLWNoZWNrZWQgLm1hdC1yYWRpby1vdXRlci1jaXJjbGUsIC5tYXQtcmFkaW8tYnV0dG9uLm1hdC1hY2NlbnQgLm1hdC1yYWRpby1pbm5lci1jaXJjbGUge1xuICAgIGJhY2tncm91bmQtY29sb3I6IGJsYWNrICFpbXBvcnRhbnQ7XG4gICAgYm9yZGVyOiA2cHggc29saWQgIzgwODA4MCAhaW1wb3J0YW50O1xuICB9XG5cbiAgLmJ0bi1ub1ByaW50IHtcbiAgICBkaXNwbGF5OiBub25lO1xuICB9XG59XG50YWJsZSwgdGFibGUgdGQge1xuICBib3JkZXItY29sbGFwc2U6IHNlcGFyYXRlO1xufVxuXG4ubmV4dEJ0biB7XG4gIHBhZGRpbmctdG9wOiAwcHg7XG59XG5cbi5tYXQtaWNvbkluc2lkZUJ0biB7XG4gIHBvc2l0aW9uOiByZWxhdGl2ZSAhaW1wb3J0YW50O1xuICB0b3A6IDZweCAhaW1wb3J0YW50O1xufVxuXG4ucHJpbnRJY29uIHtcbiAgaGVpZ2h0OiAzNXB4O1xuICB3aWR0aDogMzVweDtcbiAgZmxvYXQ6IHJpZ2h0O1xuICBmb250LXNpemU6IDI3cHg7XG59XG5cbi8qLm1hdC1jaGlwLWxpc3Qtd3JhcHBlciAubWF0LXN0YW5kYXJkLWNoaXAsIC5tYXQtY2hpcC1saXN0LXdyYXBwZXIgaW5wdXQubWF0LWlucHV0LWVsZW1lbnQge1xuICBtYXJnaW46IDRweDtcbn0qL1xuLm1hdC1zdGFuZGFyZC1jaGlwLm1hdC1jaGlwLXdpdGgtdHJhaWxpbmctaWNvbiB7XG4gIHBhZGRpbmctdG9wOiA1cHggIWltcG9ydGFudDtcbiAgcGFkZGluZy1ib3R0b206IDVweCAhaW1wb3J0YW50O1xuICBwYWRkaW5nLXJpZ2h0OiA2cHggIWltcG9ydGFudDtcbiAgcGFkZGluZy1sZWZ0OiA2cHggIWltcG9ydGFudDtcbn1cblxuLm1hdC1zdGFuZGFyZC1jaGlwW19uZ2NvbnRlbnQtYzldIHtcbiAgYm9yZGVyLXJhZGl1czogMTBweDtcbn1cblxuLm1hdC1jaGlwLm1hdC1zdGFuZGFyZC1jaGlwIHtcbiAgYmFja2dyb3VuZC1jb2xvcjogd2hpdGU7XG4gIGNvbG9yOiByZ2JhKDc1LCA3NCwgNzQsIDAuODcpO1xuICBib3JkZXI6IDFweCBzb2xpZCAjNmU2ZTZlO1xuICBmb250LXdlaWdodDogNzAwO1xufVxuXG4ubm9Cb3JkZXIge1xuICBib3JkZXI6IG5vbmU7XG4gIG91dGxpbmU6IG5vbmU7XG4gIHdpZHRoOiBjYWxjKDEwMCUgLSAxMHB4ICk7XG59XG5cbi5uby11bmRlcmxpbmUgLm1hdC1mb3JtLWZpZWxkLXVuZGVybGluZSB7XG4gIGhlaWdodDogMHB4ICFpbXBvcnRhbnQ7XG59XG5cbi5uby1kaXNwbGF5IHtcbiAgZGlzcGxheTogbm9uZSAhaW1wb3J0YW50O1xufVxuXG4ubWF0LXN0YW5kYXJkLWNoaXAge1xuICBib3JkZXItcmFkaXVzOiAxMHB4O1xufVxuXG50ci5tYXQtcm93IHtcbiAgaGVpZ2h0OiAzOHB4O1xufVxuXG4uaW52YWxpZCB7XG4gIGJvcmRlci1ib3R0b206IDFweDtcbiAgYm9yZGVyLWJvdHRvbS1jb2xvcjogcmVkO1xuICBib3JkZXItYm90dG9tLXN0eWxlOiBzb2xpZDtcbn1cblxuLmhpZ2gtcmVkIHtcbiAgYm9yZGVyOiBzb2xpZCAxcHggcmVkO1xuICBwYWRkaW5nLWxlZnQ6IDRweDtcbiAgcGFkZGluZy1yaWdodDogNHB4O1xuICBib3JkZXItcmFkaXVzOiA1cHg7XG59XG5cbnRkLm1hdC1jZWxsOmZpcnN0LW9mLXR5cGUsIHRkLm1hdC1mb290ZXItY2VsbDpmaXJzdC1vZi10eXBlLCB0aC5tYXQtaGVhZGVyLWNlbGw6Zmlyc3Qtb2YtdHlwZSB7XG4gIHBhZGRpbmctbGVmdDogNXB4O1xufVxuXG50ZC5tYXQtY2VsbDpsYXN0LW9mLXR5cGUsIHRkLm1hdC1mb290ZXItY2VsbDpsYXN0LW9mLXR5cGUsIHRoLm1hdC1oZWFkZXItY2VsbDpsYXN0LW9mLXR5cGUge1xuICBwYWRkaW5nLXJpZ2h0OiA1cHg7XG59XG5cbi5jb250YWluZXJUaXRsZSB7XG4gIG1hcmdpbi1ib3R0b206IDI1cHg7XG4gIG1hcmdpbi10b3A6IDUwcHg7XG4gIC8qIHBhZGRpbmctdG9wOiAzMHB4OyAqL1xuICBiYWNrZ3JvdW5kLWNvbG9yOiAjYzJjMmRlO1xuICB0ZXh0LWFsaWduOiBjZW50ZXI7XG4gIHBhZGRpbmc6IDIwcHg7XG4gIG1hcmdpbi1sZWZ0OiAtMTVweDtcbiAgbWFyZ2luLXJpZ2h0OiAtMTVweDtcbiAgYm9yZGVyLXJhZGl1czogOHB4IDhweCAwIDA7XG59XG5cbi5tYXQtZXhwYW5zaW9uLXBhbmVsOm5vdCgubWF0LWV4cGFuZGVkKSAubWF0LWV4cGFuc2lvbi1wYW5lbC1oZWFkZXI6bm90KFthcmlhLWRpc2FibGVkPXRydWVdKSB7XG4gIGJhY2tncm91bmQ6ICNmNmY2ZmY7XG59XG5cbi5tYXQtZXhwYW5zaW9uLXBhbmVsIHtcbiAgcGFnZS1icmVhay1iZWZvcmU6IGFsd2F5cztcbn0iXX0= */"

/***/ }),

/***/ "./src/app/home/home.component.ts":
/*!****************************************!*\
  !*** ./src/app/home/home.component.ts ***!
  \****************************************/
/*! exports provided: HomeComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HomeComponent", function() { return HomeComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm2015/forms.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm2015/router.js");
/* harmony import */ var _angular_material__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/material */ "./node_modules/@angular/material/esm2015/material.js");
/* harmony import */ var _angular_cdk_keycodes__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/cdk/keycodes */ "./node_modules/@angular/cdk/esm2015/keycodes.js");
/* harmony import */ var _common_validators_custom_validators__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../common/validators/custom.validators */ "./src/app/common/validators/custom.validators.ts");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm2015/http.js");








let HomeComponent = class HomeComponent {
    constructor(router, fb, http) {
        this.router = router;
        this.fb = fb;
        this.http = http;
        this.pageTitle = 'Additional Entities';
        this.isSubmittedForm = false;
        // values: any;
        this.displayedColumns = ['nameOfCorp', 'percentOwnership', 'actions'];
        this.dataSourceCorpOwner = new _angular_material__WEBPACK_IMPORTED_MODULE_4__["MatTableDataSource"]([]);
        this.dataSourceAditionalEntArr = [new _angular_material__WEBPACK_IMPORTED_MODULE_4__["MatTableDataSource"]([{ corpOwnerName: '', percentOwnership: '' }])];
        this.separatorKeysCodes = [_angular_cdk_keycodes__WEBPACK_IMPORTED_MODULE_5__["ENTER"], _angular_cdk_keycodes__WEBPACK_IMPORTED_MODULE_5__["SEMICOLON"]];
    }
    ngOnInit() {
        // this.getValues();
        this.form = this.fb.group({
            noAditionalCorp: [false],
            corpOwners: this.fb.array([this.GetCorpOwnerArrGroup()], [_common_validators_custom_validators__WEBPACK_IMPORTED_MODULE_6__["ValidateArray100percent"]]),
            aditionalEntities: this.fb.array([this.GetAditionalEntitiesArrGroup()]),
        });
        this.dataSourceCorpOwner = new _angular_material__WEBPACK_IMPORTED_MODULE_4__["MatTableDataSource"](this.form.value.corpOwners);
        window.onbeforeprint = () => {
            const ent = this.form.controls.aditionalEntities;
            console.log(ent);
            ent.controls.forEach(el => {
                el['controls'].isExpanded.setValue(true);
            });
        };
    }
    //getValues() {
    //  this.http.get('http://localhost:55379/api/affiliates/1340126').subscribe(response => {
    //    this.values = response;
    //    console.log(response);
    //  }, error => {
    //    console.log(error);
    //  });
    //}
    updateAditionalEntities() {
        let nAditional = [];
        for (let j = 0; j < this.AdditionalEnt.length; j++) {
            nAditional.push(new _angular_material__WEBPACK_IMPORTED_MODULE_4__["MatTableDataSource"](this.AdditionalEnt.value[j].AditEntcorpOwners));
            console.log(this.AdditionalEnt.value[j].AditEntcorpOwners);
        }
        this.dataSourceAditionalEntArr = nAditional;
    }
    get AdditionalEnt() {
        return this.form.get('aditionalEntities');
    }
    getAditEntcorpOwners(iter) {
        //console.log( === 1);
        const test = parseInt(iter);
        return this.AdditionalEnt[test.toString()].controls.AditEntcorpOwners;
    }
    GetCorpOwnerArrGroup() {
        return this.fb.group({
            corpOwnerName: ['', _angular_forms__WEBPACK_IMPORTED_MODULE_2__["Validators"].required],
            percentOwnership: [null, _angular_forms__WEBPACK_IMPORTED_MODULE_2__["Validators"].required]
        });
    }
    removeCorpOwners(i) {
        const corpOw = this.form.controls.corpOwners;
        corpOw.removeAt(i);
        this.dataSourceCorpOwner = new _angular_material__WEBPACK_IMPORTED_MODULE_4__["MatTableDataSource"](this.form.value.corpOwners);
    }
    addCorpOwners() {
        const corpOw = this.form.controls.corpOwners;
        corpOw.push(this.GetCorpOwnerArrGroup());
        this.dataSourceCorpOwner = new _angular_material__WEBPACK_IMPORTED_MODULE_4__["MatTableDataSource"](this.form.value.corpOwners);
    }
    checkIfAddNewCorpOwner(i) {
        const corpOw = this.form.controls.corpOwners;
        if ((i + 1) == this.form.value.corpOwners.length) {
            if (corpOw.controls[i].valid) {
                this.addCorpOwners();
                setTimeout(() => {
                    this.corpOwnerNameField.toArray()[i + 1].nativeElement.focus();
                }, 0);
            }
        }
    }
    GetAditionalEntitiesArrGroup() {
        return this.fb.group({
            legalName: ['', _angular_forms__WEBPACK_IMPORTED_MODULE_2__["Validators"].required],
            zipCode: ['', _angular_forms__WEBPACK_IMPORTED_MODULE_2__["Validators"].required],
            dba: [[]],
            isExpanded: [true],
            AditEntcorpOwners: this.fb.array([this.GetCorpOwnerArrGroup()], [_common_validators_custom_validators__WEBPACK_IMPORTED_MODULE_6__["ValidateArray100percent"]]),
        });
    }
    addDBA(event, i) {
        const input = event.input;
        const value = event.value;
        // Add DBA
        if ((value || '').trim()) {
            this.form.controls.aditionalEntities['controls'][i].value.dba.push(value.trim().toUpperCase());
            this.form.controls.aditionalEntities['controls'][i].controls.dba.setValue(this.form.controls.aditionalEntities['controls'][i].value.dba);
        }
        // Reset the input value
        if (input) {
            input.value = '';
        }
    }
    removeDBA(el, i) {
        const index = this.form.controls.aditionalEntities['controls'][i].value.dba.indexOf(el);
        if (index >= 0) {
            this.form.controls.aditionalEntities['controls'][i].value.dba.splice(index, 1);
            this.form.controls.aditionalEntities['controls'][i].controls.dba.setValue(this.form.controls.aditionalEntities['controls'][i].value.dba);
        }
        console.log(i);
    }
    addAditionalEntity() {
        const ent = this.form.controls.aditionalEntities;
        console.log(ent);
        ent.controls.forEach(el => {
            el['controls'].isExpanded.setValue(false);
        });
        ent.push(this.GetAditionalEntitiesArrGroup());
        this.updateAditionalEntities();
    }
    removeAditionalEntity(i) {
        const ent = this.form.controls.aditionalEntities;
        ent.removeAt(i);
        this.updateAditionalEntities();
    }
    submitForm() {
        this.isSubmittedForm = true;
        this.form.controls.aditionalEntities['controls'].forEach(el => {
            if (!el.valid) {
                el.controls.isExpanded.setValue(true);
            }
        });
        console.log(JSON.stringify(this.form.value, null, 2));
        console.log(this.form);
        if (this.form.valid || !this.form.value.noAditionalCorp) {
            this.goToemployeeprofileepl();
        }
    }
    setIsExpanded(i, val) {
        this.form.controls.aditionalEntities['controls'][i].controls.isExpanded.setValue(val);
    }
    logElem(el) {
        console.log(el);
    }
    addNewAditionalEntRow(i) {
        const ent = this.form.controls.aditionalEntities['controls'][i].controls.AditEntcorpOwners;
        ent.push(this.AddAditionalEntArrGroup());
        this.updateAditionalEntities();
    }
    deleteAditionalEntRow(i, j) {
        const ent = this.form.controls.aditionalEntities['controls'][i].controls.AditEntcorpOwners;
        ent.removeAt(j);
        this.updateAditionalEntities();
    }
    checkIfAddNewAditionalEntiyRow(i, j) {
        const ent = this.form.controls.aditionalEntities['controls'][i].controls.AditEntcorpOwners;
        if (ent.controls[j].valid) {
            this.addNewAditionalEntRow(i);
        }
        console.log(i, j);
        setTimeout(() => {
            const arrEl = this.corpOwnerEntityNameField.filter(el => {
                return el.nativeElement.id == i;
            });
            arrEl[arrEl.length - 1].nativeElement.focus();
        }, 0);
    }
    AddAditionalEntArrGroup() {
        return this.fb.group({
            corpOwnerName: ['', _angular_forms__WEBPACK_IMPORTED_MODULE_2__["Validators"].required],
            percentOwnership: [null, _angular_forms__WEBPACK_IMPORTED_MODULE_2__["Validators"].required]
        });
    }
    getAditionalECorOwner(i) {
        console.log(this.form.controls.aditionalEntities['controls'][i].value.AditEntcorpOwners);
    }
    goToCurrentInsuranceInfo() {
        this.router.navigate(['us/currentinsuranceinfoepl']);
    }
    goToemployeeprofileepl() {
        this.router.navigate(['us/employeeprofileepl']);
    }
    onCloseClick() {
    }
};
tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["ViewChildren"])("corpOwnerNameField"),
    tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", _angular_core__WEBPACK_IMPORTED_MODULE_1__["QueryList"])
], HomeComponent.prototype, "corpOwnerNameField", void 0);
tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["ViewChildren"])("corpOwnerEntityNameField"),
    tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", _angular_core__WEBPACK_IMPORTED_MODULE_1__["QueryList"])
], HomeComponent.prototype, "corpOwnerEntityNameField", void 0);
HomeComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
        selector: 'app-home',
        template: __webpack_require__(/*! raw-loader!./home.component.html */ "./node_modules/raw-loader/index.js!./src/app/home/home.component.html"),
        styles: [__webpack_require__(/*! ./home.component.scss */ "./src/app/home/home.component.scss")]
    }),
    tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_3__["Router"],
        _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormBuilder"],
        _angular_common_http__WEBPACK_IMPORTED_MODULE_7__["HttpClient"]])
], HomeComponent);



/***/ }),

/***/ "./src/app/material/material.module.ts":
/*!*********************************************!*\
  !*** ./src/app/material/material.module.ts ***!
  \*********************************************/
/*! exports provided: MaterialModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "MaterialModule", function() { return MaterialModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_cdk_drag_drop__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/cdk/drag-drop */ "./node_modules/@angular/cdk/esm2015/drag-drop.js");
/* harmony import */ var _angular_cdk_stepper__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/cdk/stepper */ "./node_modules/@angular/cdk/esm2015/stepper.js");
/* harmony import */ var _angular_cdk_table__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/cdk/table */ "./node_modules/@angular/cdk/esm2015/table.js");
/* harmony import */ var _angular_cdk_tree__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/cdk/tree */ "./node_modules/@angular/cdk/esm2015/tree.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_material__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/material */ "./node_modules/@angular/material/esm2015/material.js");


//import { PortalModule } from '@angular/cdk/portal';
//import { ScrollingModule } from '@angular/cdk/scrolling';





let MaterialModule = class MaterialModule {
};
MaterialModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_5__["NgModule"])({
        exports: [
            //A11yModule,
            _angular_cdk_stepper__WEBPACK_IMPORTED_MODULE_2__["CdkStepperModule"],
            _angular_cdk_table__WEBPACK_IMPORTED_MODULE_3__["CdkTableModule"],
            _angular_cdk_tree__WEBPACK_IMPORTED_MODULE_4__["CdkTreeModule"],
            _angular_cdk_drag_drop__WEBPACK_IMPORTED_MODULE_1__["DragDropModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatAutocompleteModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatBadgeModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatBottomSheetModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatButtonModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatButtonToggleModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatCardModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatCheckboxModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatChipsModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatStepperModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatDatepickerModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatDialogModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatDividerModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatExpansionModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatGridListModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatIconModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatInputModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatListModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatMenuModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatNativeDateModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatPaginatorModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatProgressBarModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatProgressSpinnerModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatRadioModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatRippleModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatSelectModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatSidenavModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatSliderModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatSlideToggleModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatSnackBarModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatSortModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatTableModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatTabsModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatToolbarModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatTooltipModule"],
            _angular_material__WEBPACK_IMPORTED_MODULE_6__["MatTreeModule"],
        ]
    })
], MaterialModule);



/***/ }),

/***/ "./src/environments/environment.ts":
/*!*****************************************!*\
  !*** ./src/environments/environment.ts ***!
  \*****************************************/
/*! exports provided: environment */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "environment", function() { return environment; });
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
const environment = {
    production: false
};
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ "./src/main.ts":
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser-dynamic */ "./node_modules/@angular/platform-browser-dynamic/fesm2015/platform-browser-dynamic.js");
/* harmony import */ var _app_app_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./app/app.module */ "./src/app/app.module.ts");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./environments/environment */ "./src/environments/environment.ts");




if (_environments_environment__WEBPACK_IMPORTED_MODULE_3__["environment"].production) {
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["enableProdMode"])();
}
Object(_angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__["platformBrowserDynamic"])().bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_2__["AppModule"])
    .catch(err => console.error(err));


/***/ }),

/***/ 0:
/*!***************************!*\
  !*** multi ./src/main.ts ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! C:\XDRIVE\IT_Projects\ELD_PLD\DEVELOPMENT\InternalWebApplication\AffiliateInfo\AffiliateInfo\ClientApp\src\main.ts */"./src/main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main.js.map