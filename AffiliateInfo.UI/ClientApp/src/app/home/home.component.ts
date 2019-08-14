import { Component, OnInit, QueryList, ViewChildren, ElementRef } from '@angular/core';
import { FormGroup, Validators, FormBuilder, FormArray, NgForm, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { MatTableDataSource, MatChipInputEvent } from '@angular/material';
import { ENTER, SEMICOLON } from '@angular/cdk/keycodes';
import { Subscription } from 'rxjs';
import { ValidateArray100percent } from '../common/validators/custom.validators';
import { HttpClient } from '@angular/common/http';
import { AffiliateInfoService } from '../services/affiliate-info.service';
import { CorpOwner, AdditionalEntity, AdditionalEntityOwner, AffiliateInfo } from '../models/affiliate-info.model';
import { isNumber } from 'util';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  pageTitle: string = 'Additional Entities';
  public form: FormGroup;
  isSubmittedForm = false;
  masterSheetId: number;
  //values: any;

  displayedColumns: string[] = ['nameOfCorp', 'percentOwnership', 'actions'];

  dataSourceCorpOwner = new MatTableDataSource<any>([]);
  dataSourceAdditionalEntArr = [new MatTableDataSource<any>([{ corpOwnerName: '', percentOwnership: '' }])];

  @ViewChildren("corpOwnerNameField") corpOwnerNameField: QueryList<ElementRef>
  @ViewChildren("corpOwnerEntityNameField") corpOwnerEntityNameField: QueryList<ElementRef>

  readonly separatorKeysCodes: number[] = [ENTER, SEMICOLON];

  affiliateModel: AffiliateInfo;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private http: HttpClient,
    private service: AffiliateInfoService
  ) {
  }

  ngOnInit() {
    console.log('route params', this.route.snapshot.params);
    this.masterSheetId = this.route.snapshot.params.masterSheetId;
    this.service.getAffiliateInfo(this.masterSheetId).subscribe(res => {
      this.affiliateModel = res;
      this.affiliateModel.masterSheetId = this.masterSheetId;
      this.setCorpOwners(this.affiliateModel.corpOwners);
      this.setAdditionalEntities(this.affiliateModel.additionalEntities);
      console.log(res.corpOwners);
      console.log(res.additionalEntities);
      // this.form.setControl('additionalEnitities', this.fb.array(res.additionalEnitities || []));
    });
    //this.service.getAffiliateInfo().subscribe(res=>{
    //this.form.corpOwners.setValue(res.corpOwners)
    //this.form.AdditionalE.setValue(res.AdditionalE)
    //});

    //this.getValues();
    this.form = this.fb.group({
      corpOwners: this.fb.array([this.GetCorpOwnerArrGroup()], [ValidateArray100percent]),
      additionalEntities: this.fb.array([this.GetAdditionalEntitiesArrGroup()])
    });

    this.dataSourceCorpOwner = new MatTableDataSource<any>(this.form.value.corpOwners);
    this.dataSourceAdditionalEntArr = [new MatTableDataSource<any>(this.form.value.additionalEntities)];

    window.onbeforeprint = () => {
      const ent = this.form.controls.additionalEntities as FormArray
      console.log(ent)
      ent.controls.forEach(el => {
        el['controls'].isExpanded.setValue(true);
      })
    }
  }

  //getValues() {
  //  this.http.get('http://localhost:55379/api/affiliates/1340126').subscribe(response => {
  //    this.values = response;
  //    console.log(response);
  //  }, error => {
  //    console.log(error);
  //  });
  //}

  setCorpOwners(owners: CorpOwner[]) {
    //this.dataSourceCorpOwner = new MatTableDataSource<any>([]);
    let ow = this.form.controls['corpOwners'] as FormArray;
    ow.clear();
    for (let owner of owners) {
      ow.push(this.GetCorpOwnerArrGroup(owner));
    }
    this.dataSourceCorpOwner = new MatTableDataSource<any>(owners);
  }

  setAdditionalEntities(entities: AdditionalEntity[]) {
    //this.dataSourceAdditionalEntArr = [new MatTableDataSource<any>([])];
    let ae = this.form.controls['additionalEntities'] as FormArray;
    ae.clear();
    for (let entity of entities) {
      ae.push(this.GetAdditionalEntitiesArrGroup(entity));
    }
    this.dataSourceAdditionalEntArr = [new MatTableDataSource<any>([entities])];
    this.updateAdditionalEntities();
  }

  updateAdditionalEntities() {
    let nAdditional = [];
    for (let j = 0; j < this.AdditionalEnt.length; j++) {
      nAdditional.push(new MatTableDataSource<any>(this.AdditionalEnt.value[j].AdditEntcorpOwners));
      console.log(this.AdditionalEnt.value[j].AdditEntcorpOwners)
    }
    this.dataSourceAdditionalEntArr = nAdditional;
  }
  get AdditionalEnt() {
    return this.form.get('additionalEntities') as FormArray;
  }

  getAdditEntcorpOwners(iter): FormArray {
    //console.log( === 1);
    const test = parseInt(iter);
    return this.AdditionalEnt[test.toString()].controls.AdditEntcorpOwners as FormArray;
  }

  GetCorpOwnerArrGroup(owner?: CorpOwner): FormGroup {
    //console.log('test');
    //console.log(this.form);
    return this.fb.group({
      corpOwnerName: [owner && owner.corpOwnerName ? owner.corpOwnerName : '', Validators.required],
      percentOwnership: [owner && owner.corpOwnerPercent ? owner.corpOwnerPercent : null, Validators.required]
    });
  }

  GetAdditionalCorpOwnerArrGroup(owner?: AdditionalEntityOwner): FormGroup {
    return this.fb.group({
      corpOwnerName: [owner && owner.ownerName ? owner.ownerName : '', Validators.required],
      percentOwnership: [owner && owner.ownerPercent ? owner.ownerPercent : null, Validators.required]
    });
  }

  removeCorpOwners(i) {
    const corpOw = this.form.controls.corpOwners as FormArray;
    corpOw.removeAt(i);
    this.affiliateModel.corpOwners.splice(i, 1);
    this.dataSourceCorpOwner = new MatTableDataSource<any>(this.form.value.corpOwners);
  }

  addCorpOwners() {
    const corpOw = this.form.controls.corpOwners as FormArray;
    const ownerGroup = this.GetCorpOwnerArrGroup();
    corpOw.push(ownerGroup);
    console.log('adding corp owner', this.affiliateModel);
    const newOwnerModel: CorpOwner = {
      corpOwnerId: 0,
      masterSheetId: this.affiliateModel.masterSheetId,
      corpOwnerName: '',
      corpOwnerPercent: 0,
      lastChangedDate: new Date(),
      lastChangedId: undefined
    }

    this.applyFormGroupToCorpOwnerModel(ownerGroup, newOwnerModel);
    this.affiliateModel.corpOwners.push(newOwnerModel);

    this.dataSourceCorpOwner = new MatTableDataSource<any>(this.form.value.corpOwners);
  }

  checkIfAddNewCorpOwner(i) {
    const corpOw = this.form.controls.corpOwners as FormArray;
    if ((i + 1) == this.form.value.corpOwners.length) {
      if (corpOw.controls[i].valid) {
        this.addCorpOwners();
        setTimeout(() => {
          this.corpOwnerNameField.toArray()[i + 1].nativeElement.focus();
        }, 0)
      }
    }
  }

  GetAdditionalEntitiesArrGroup(entity?: AdditionalEntity): FormGroup {
    return this.fb.group({
      legalName: [entity && entity.legalName ? entity.legalName : '', Validators.required],
      zip: [entity && entity.zip ? entity.zip : '', Validators.required],
      dbaname: [entity && entity.dbaname ? entity.dbaname.split(';') : []],
      isExpanded: [true],
      AdditEntcorpOwners: this.fb.array(entity && entity.additionalEntityOwner
        ? entity.additionalEntityOwner.map(owner => this.GetAdditionalCorpOwnerArrGroup(owner))
        : [this.GetAdditionalCorpOwnerArrGroup()], [ValidateArray100percent]),
    });
  }

  addDBA(event: MatChipInputEvent, i) {
    const input = event.input;
    const value = event.value;
    // Add DBA
    if ((value || '').trim()) {
      this.form.controls.additionalEntities['controls'][i].value.dbaname.push(value.trim().toUpperCase());
      this.form.controls.additionalEntities['controls'][i].controls.dbaname.setValue(this.form.controls.additionalEntities['controls'][i].value.dbaname);
    }
    // Reset the input value
    if (input) {
      input.value = '';
    }
  }
  removeDBA(el: any, i): void {
    const index = this.form.controls.additionalEntities['controls'][i].value.dbaname.indexOf(el);
    if (index >= 0) {
      this.form.controls.additionalEntities['controls'][i].value.dbaname.splice(index, 1);
      this.form.controls.additionalEntities['controls'][i].controls.dbaname.setValue(
        this.form.controls.additionalEntities['controls'][i].value.dbaname);
    }
    console.log(i)
  }

  addAdditionalEntity() {
    const addEnt = this.form.controls.additionalEntities as FormArray
    const entityGroup = this.GetAdditionalEntitiesArrGroup();
    addEnt.push(entityGroup);
    console.log('adding additional entity', this.affiliateModel);
    const newAddEntityModel: AdditionalEntity = {
      entityId: 0,
      legalName: '',
      dbaname: '',
      zip: '',
      additionalEntityOwner: [],
      masterSheetId: this.affiliateModel.masterSheetId
    }
    this.affiliateModel.additionalEntities.push(newAddEntityModel);
    //console.log(ent)
    //ent.controls.forEach(el => {
    //  el['controls'].isExpanded.setValue(false);
    //})
    //ent.push(this.GetAdditionalEntitiesArrGroup());
    this.updateAdditionalEntities();
  }

  removeAdditionalEntity(i) {
    const ent = this.form.controls.additionalEntities as FormArray;
    ent.removeAt(i);
    this.affiliateModel.additionalEntities.splice(i, 1);
    this.updateAdditionalEntities();
  }

  submitForm() {
    this.isSubmittedForm = true;
    this.form.controls.additionalEntities['controls'].forEach(el => {
      if (!el.valid) {
        el.controls.isExpanded.setValue(true);
      }
    });
    if (this.form.invalid) {
      return;
    }

    console.log(this.form.value);

    this.updateAffiliateInfoFromForm();

    /*const data = this.form.value;
    data.isExpanded = undefined;
    data.corpOwners = this.form.value.corpOwners
      .map(entity => {
        const corpData = entity;
        corpData.masterSheetId = this.masterSheetId;
        return corpData;
      });
    data.additionalEntities = this.form.value.additionalEntities
      .map(entity => {
        const entityData = entity;
        //console.log('this is entity', entity.dbaname)

        entityData.dbaname = entity.dbaname && entity.dbaname.length ? entity.dbaname.join(';') : '';

        entityData.masterSheetId = this.masterSheetId;
        return entityData;
      });
    data.masterSheetId = this.masterSheetId; */
    //data.AdditionalEntities.forEach(entity => entity.masterSheetId = this.masterSheetId);
    //data.AdditionalEntities.forEach(entity => entity.masterSheetId = this.masterSheetId);

    this.service.putAffiliateInfo(this.affiliateModel).subscribe(
      response => {
        console.log(response);
      },
      error => {
        console.log(error)
      }
    )

    console.log(JSON.stringify(this.form.value, null, 2));
  }

  setIsExpanded(i, val) {
    this.form.controls.additionalEntities['controls'][i].controls.isExpanded.setValue(val)
  }

  addNewAdditionalEntRow(i) {
    const ent = this.form.controls.additionalEntities['controls'][i].controls.AdditEntcorpOwners as FormArray
    ent.push(this.AddAdditionalEntArrGroup());
    this.updateAdditionalEntities()
  }

  deleteAdditionalEntRow(i, j) {
    const ent = this.form.controls.additionalEntities['controls'][i].controls.AdditEntcorpOwners as FormArray
    ent.removeAt(j);
    this.affiliateModel.additionalEntities[i].additionalEntityOwner.splice(j, 1);
    this.updateAdditionalEntities()
  }

  checkIfAddNewAdditionalEntiyRow(i, j) {
    const ent = this.form.controls.additionalEntities['controls'][i].controls.AdditEntcorpOwners as FormArray
    if (ent.controls[j].valid) {
      this.addNewAdditionalEntRow(i);
    }

    console.log(i, j)
    setTimeout(() => {
      const arrEl = this.corpOwnerEntityNameField.filter(el => {
        return el.nativeElement.id == i;
      })
      arrEl[arrEl.length - 1].nativeElement.focus();
    }, 0)
  }

  AddAdditionalEntArrGroup(): FormGroup {
    return this.fb.group({
      corpOwnerName: ['', Validators.required],
      percentOwnership: [null, Validators.required]
    });
  }

  getAdditionalECorOwner(i) {
    console.log(this.form.controls.additionalEntities['controls'][i].value.AdditEntcorpOwners)
  }

  goToCurrentInsuranceInfo() {
    this.router.navigate(['us/currentinsuranceinfoepl']);
  }
  goToemployeeprofileepl() {
    this.router.navigate(['us/employeeprofileepl']);
  }

  //closeWindow() {
  //  this.closeWindow();
  //}

  onSaveCloseClick(form?: NgForm): void {
  }

  updateAffiliateInfoFromForm() {
    this.updateOwnerModelFromForm();
    this.updateAdditionalEntityModelFromForm();

    console.log('affiliate', this.affiliateModel);
  }

  updateOwnerModelFromForm() {
    const ownerControlArray = this.form.controls.corpOwners as FormArray;
    for (let i = 0; i < this.affiliateModel.corpOwners.length; i++) {
      if (ownerControlArray.controls[i]) {
        this.applyFormGroupToCorpOwnerModel((ownerControlArray.controls[i] as FormGroup), this.affiliateModel.corpOwners[i]);
      }
    }
  }

  updateAdditionalEntityModelFromForm() {
    const entityControlArray = this.form.controls.additionalEntities as FormArray;
    for (let i = 0; i < this.affiliateModel.additionalEntities.length; i++) {
      if (entityControlArray.controls[i]) {
        this.applyFormGroupToAdditionalEntityModel((entityControlArray.controls[i] as FormGroup), this.affiliateModel.additionalEntities[i]);
      }
    }
  }

  applyFormGroupToAdditionalEntityModel(entityGroup: FormGroup, entityModel: AdditionalEntity) {
    entityModel.legalName = entityGroup.value.legalName;
    entityModel.dbaname = entityGroup.value.dbaname.join(';');
    entityModel.zip = entityGroup.value.zip;

    const entityOwnerGroupArray = entityGroup.controls.AdditEntcorpOwners as FormArray;
    for (let i = 0; i < entityModel.additionalEntityOwner.length; i++) {
      this.applyFormGroupToAddEntOwnerModel((entityOwnerGroupArray.controls[i] as FormGroup), entityModel.additionalEntityOwner[i]);
    }
  }

  applyFormGroupToAddEntOwnerModel(ownerGroup: FormGroup, owner: AdditionalEntityOwner) {
    owner.ownerName = ownerGroup.value.corpOwnerName;
    owner.ownerPercent = +ownerGroup.value.percentOwnership;
  }

  applyFormGroupToCorpOwnerModel(ownerGroup: FormGroup, owner: CorpOwner) {
    owner.corpOwnerName = ownerGroup.value.corpOwnerName;
    owner.corpOwnerPercent = +ownerGroup.value.percentOwnership;
  }
}
