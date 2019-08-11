import { Component, OnInit, QueryList, ViewChildren, ElementRef } from '@angular/core';
import { FormGroup, Validators, FormBuilder, FormArray, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { MatTableDataSource, MatChipInputEvent } from '@angular/material';
import { ENTER, SEMICOLON } from '@angular/cdk/keycodes';
import { Subscription } from 'rxjs';
import { ValidateArray100percent } from '../common/validators/custom.validators';
import { HttpClient } from '@angular/common/http';
import { AffiliateInfoService } from '../services/affiliate-info.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  pageTitle: string = 'Additional Entities';
  public form: FormGroup;
  isSubmittedForm = false;
  //values: any;

  displayedColumns: string[] = ['nameOfCorp', 'percentOwnership', 'actions'];

  dataSourceCorpOwner = new MatTableDataSource<any>([]);
  dataSourceAditionalEntArr = [new MatTableDataSource<any>([{ corpOwnerName: '', percentOwnership: '' }])];

  @ViewChildren("corpOwnerNameField") corpOwnerNameField: QueryList<ElementRef>
  @ViewChildren("corpOwnerEntityNameField") corpOwnerEntityNameField: QueryList<ElementRef>

  readonly separatorKeysCodes: number[] = [ENTER, SEMICOLON];

  aditionalEntitiesSubscription: Subscription;

  constructor(
    private router: Router,
    private fb: FormBuilder,
    private http: HttpClient,
    private service: AffiliateInfoService
  ) { }

  ngOnInit() {
    //this.getValues();
    this.form = this.fb.group({
      noAditionalCorp: [false],
      corpOwners: this.fb.array([this.GetCorpOwnerArrGroup()], [ValidateArray100percent]),
      aditionalEntities: this.fb.array([this.GetAditionalEntitiesArrGroup()]),
    });
    this.dataSourceCorpOwner = new MatTableDataSource<any>(this.form.value.corpOwners);

    window.onbeforeprint = () => {
      const ent = this.form.controls.aditionalEntities as FormArray
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

  updateAditionalEntities() {
    let nAditional = [];
    for (let j = 0; j < this.AdditionalEnt.length; j++) {
      nAditional.push(new MatTableDataSource<any>(this.AdditionalEnt.value[j].AditEntcorpOwners));
      console.log(this.AdditionalEnt.value[j].AditEntcorpOwners)
    }
    this.dataSourceAditionalEntArr = nAditional;
  }
  get AdditionalEnt() {
    return this.form.get('aditionalEntities') as FormArray;
  }

  getAditEntcorpOwners(iter): FormArray {
    //console.log( === 1);
    const test = parseInt(iter);
    return this.AdditionalEnt[test.toString()].controls.AditEntcorpOwners as FormArray;
  }

  GetCorpOwnerArrGroup(): FormGroup {
    return this.fb.group({
      corpOwnerName: ['', Validators.required],
      percentOwnership: [null, Validators.required]
    });
  }

  removeCorpOwners(i) {
    const corpOw = this.form.controls.corpOwners as FormArray;
    corpOw.removeAt(i);
    this.dataSourceCorpOwner = new MatTableDataSource<any>(this.form.value.corpOwners);
  }

  addCorpOwners() {
    const corpOw = this.form.controls.corpOwners as FormArray;
    corpOw.push(this.GetCorpOwnerArrGroup());
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

  GetAditionalEntitiesArrGroup(): FormGroup {
    return this.fb.group({
      legalName: ['', Validators.required],
      zipCode: ['', Validators.required],
      dba: [[]],
      isExpanded: [true],

      AditEntcorpOwners: this.fb.array([this.GetCorpOwnerArrGroup()], [ValidateArray100percent]),
    });
  }

  addDBA(event: MatChipInputEvent, i) {
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
  removeDBA(el: any, i): void {
    const index = this.form.controls.aditionalEntities['controls'][i].value.dba.indexOf(el);
    if (index >= 0) {
      this.form.controls.aditionalEntities['controls'][i].value.dba.splice(index, 1);
      this.form.controls.aditionalEntities['controls'][i].controls.dba.setValue(
        this.form.controls.aditionalEntities['controls'][i].value.dba);
    }
    console.log(i)
  }

  addAditionalEntity() {
    const ent = this.form.controls.aditionalEntities as FormArray
    console.log(ent)
    ent.controls.forEach(el => {
      el['controls'].isExpanded.setValue(false);
    })
    ent.push(this.GetAditionalEntitiesArrGroup());
    this.updateAditionalEntities();
  }

  removeAditionalEntity(i) {
    const ent = this.form.controls.aditionalEntities as FormArray
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
    this.form.controls.aditionalEntities['controls'][i].controls.isExpanded.setValue(val)
  }

  logElem(el) {
    console.log(el)
  }

  addNewAditionalEntRow(i) {
    const ent = this.form.controls.aditionalEntities['controls'][i].controls.AditEntcorpOwners as FormArray
    ent.push(this.AddAditionalEntArrGroup());
    this.updateAditionalEntities()
  }

  deleteAditionalEntRow(i, j) {
    const ent = this.form.controls.aditionalEntities['controls'][i].controls.AditEntcorpOwners as FormArray
    ent.removeAt(j);
    this.updateAditionalEntities()
  }

  checkIfAddNewAditionalEntiyRow(i, j) {
    const ent = this.form.controls.aditionalEntities['controls'][i].controls.AditEntcorpOwners as FormArray
    if (ent.controls[j].valid) {
      this.addNewAditionalEntRow(i);
    }

    console.log(i, j)
    setTimeout(() => {
      const arrEl = this.corpOwnerEntityNameField.filter(el => {
        return el.nativeElement.id == i;
      })
      arrEl[arrEl.length - 1].nativeElement.focus();
    }, 0)
  }

  AddAditionalEntArrGroup(): FormGroup {
    return this.fb.group({
      corpOwnerName: ['', Validators.required],
      percentOwnership: [null, Validators.required]
    });
  }

  getAditionalECorOwner(i) {
    console.log(this.form.controls.aditionalEntities['controls'][i].value.AditEntcorpOwners)
  }

  goToCurrentInsuranceInfo() {
    this.router.navigate(['us/currentinsuranceinfoepl']);
  }
  goToemployeeprofileepl() {
    this.router.navigate(['us/employeeprofileepl']);
  }

  closeWindow(form?: NgForm) {
    if (form != null)
      form.resetForm();
    this.service.formData = {
      MasterSheetId: 0,
      CorpOwnerId: 0,
      CorpOwnerName: '',
      CorpOwnerPercent: 0,
      LastChangedDate: null,
      LastChangedId: '',
      EntityId: 0,
      LegalName: '',
      Dbaname: '',
      Zip: '',
      EntityOwnerId: 0,
      FkEntityId: 0,
      OwnerName: '',
      OwnerPercent: 0
    }
    //this.closeWindow();
  }

  onSaveCloseClick(form?: NgForm): void {
    this.service.putAffiliateInfo(form.value).subscribe(
      response => {
        this.closeWindow(form);
        console.log(response);
      },
      error => {
        console.log(error)
      }
    )
  }
}
