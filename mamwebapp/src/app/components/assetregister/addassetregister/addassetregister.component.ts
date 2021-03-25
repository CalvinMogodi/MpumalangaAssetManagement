import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MenuItem, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/internal/operators/first';
import { Facility } from 'src/app/models/facility.model';
import { FacilityService } from 'src/app/services/facility/facility.service';
import { ConfirmationService } from 'primeng/api';
import { User } from 'src/app/models/user.model';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-addassetregister',
  templateUrl: './addassetregister.component.html',
  styleUrls: ['./addassetregister.component.css'],
  providers: [MessageService, ConfirmationService]
})

export class AddassetregisterComponent implements OnInit {
  @Output() newAsset = new EventEmitter<any>();
  @Input() selectedAsset: any;
  steps: MenuItem[];
  improvements = [];
  landIsSubmitted: boolean = false;
  improvementIsSubmitted: boolean = false;
  financeIsSubmitted: boolean = false;
  isSubmitted: boolean = false;
  selectedImprovement: any;
  selectedDeedsOffice: any;
  generalInformation: {
    deedsOffice: '',
    class: '',
    type: ''
  };
  error = '';
  subscription: Subscription;
  activeItem: MenuItem;
  loading = true;
  incomeLeaseStatuses: any[];
  natureOfLeases: any[];
  showDialog: boolean = false;
  activeIndex: number = 0;
  landForm: FormGroup;
  financialForm: FormGroup;
  improvementForm: FormGroup;
  deedsOffices: any[];
  typeOfImprovements: any[];
  potentialUseList: any[];
  classes: any[];
  regions: any[];
  types: any[];
  buttonItems: MenuItem[];
  submitted = false;
  localAuthorities: any[];
  registrationDivisions: any[];
  magisterialDistricts: any[];
  districtMunicipalities: any[];
  conditionRatings: any[];
  vats: any[];
  userDepartments: any[];
  landRemainders: any[];
  howAcquireds: any[];
  howAcquired: any = {
    name: undefined
  };
  provinces: any[];
  functionalPerformanceRatings: any[];
  ownershipCategories: any;
  errorMsg: string;
  mode: string;
  province: { name: 'Mpumalanga', code: 'MP', factor: 6 };
  registrationDivision: { name: 'Mpumalanga', code: 'M', factor: 4 };
  savingLand: boolean = false;
  improvementCols = [
    { field: 'buildingName', header: 'Building Name' },
    { field: 'type', header: 'Type' },
    { field: 'size', header: 'Size' },
    { field: 'potentualUse', header: 'Potentual Use' },
    { field: 'usableArea', header: 'Usable Area' },
    { field: 'conditionRating', header: 'Condition Rating' }
  ];

  facility: any;

  finance: {};
  improvement: {}
  currentUser: User;

  constructor(private authenticationService: AuthenticationService, private confirmationService: ConfirmationService, public facilityService: FacilityService, private formBuilder: FormBuilder, private messageService: MessageService) { }

  ngOnInit() {
    this.buildForm();
    this.authenticationService.currentUser.pipe().subscribe(x => {
      this.currentUser = x;
    });

    if (this.selectedAsset.facilityId != undefined) {
      this.mode = this.selectedAsset.mode;
      if (this.mode == "Edit") {
        this.loading = false;
        this.facility = this.selectedAsset.facility;
        this.initFacility();
      } else {
        this.facilityService.getFacilityById(this.selectedAsset.facilityId, this.selectedAsset.facilityType).pipe(first()).subscribe(facility => {
          this.loading = false;
          this.facility = facility;
          this.initFacility();
        });
      }

    } else {
      this.buildForm();
      this.mode = this.selectedAsset.mode;
      this.loading = false;
    }

    this.facility = {
      id: 0,
      name: 'Land T0IS00000000000700020',
      fileReference: 'Land' + this.makeId(4),
      type: 'Land',
      clientCode: 'T0IS00000000000700020',
      userId: this.currentUser.id,
      status: "New",
      createdBy: this.currentUser.id,
      createdDate: new Date(),
      modifiedBy: this.currentUser.id,
      modifiedDate: new Date(),
      land: {
        id: 0,
        geographicalLocation: {
          id: 0
        },
        propertyDescription: {
          id: 0
        },
        landUseManagementDetail: {
          id: 0
        },
        leaseStatus: {
          id: 0
        }
      },
      finance: {
        id: 0,
        secondaryInformationNote: {
          id: 0
        },
        valuation: {
          id: 0
        }
      },
      improvements: []
    }
  }

  get l() { return this.landForm.controls; }
  get f() { return this.financialForm.controls; }
  get I() { return this.improvementForm.controls; }

  setLocalAuthorities(e) { }

  setDistrictMunicipality(e) {
    if (e != undefined) {
      if (e.value != undefined) {
        if (e.value.factor == 1) {
          this.localAuthorities = [
            { name: 'Mbombela', code: 'M', factor: 1 },
            { name: 'Nkomazi', code: 'N', factor: 2 },
            { name: 'Thaba Chweu', code: 'TC', factor: 3 },
            { name: 'Bushbuckridge', code: 'B', factor: 4 }
          ];
        } else if (e.value.factor == 2) {
          this.localAuthorities = [
            { name: 'Emalahleni', code: 'E', factor: 1 },
            { name: 'Emakahzeni', code: 'E', factor: 2 },
            { name: 'DR JS Moroka', code: 'JSM', factor: 3 },
            { name: 'Thembisile Hani', code: 'TH', factor: 4 },
            { name: 'Victor Khanye', code: 'VK', factor: 5 }
          ];
        } else {
          this.localAuthorities = [
            { name: 'Goven Mbeki', code: 'GM', factor: 1 },
            { name: 'Albert Luthuli', code: 'AL', factor: 2 },
            { name: 'Lekwa', code: 'L', factor: 3 },
            { name: 'Dipaleseng', code: 'D', factor: 4 },
            { name: 'Pixley ka Seme', code: 'PKS', factor: 5 },
            { name: 'Mkhondo', code: 'M', factor: 6 },
            { name: 'Msukaligwa', code: 'MS', factor: 7 }
          ];
        }
      }
    }
  }

  setDeedsOffice(e) {

  }

  setHowAcquired(e) {

  }

  setVat(e) { }

  setProvince(e) { }

  setMagisterialDistrict(e) { }

  setClass(e) {

  }

  setConditionRating(e) { }

  setType(e) {

  }

  onFinancialFormSubmit() {
    this.financeIsSubmitted = true;
    if (this.financialForm.valid) {
      this.assignFacility(false, true, false);
      this.facility.status = 'Saved';
      this.facilityService.saveFacility(this.facility, "finance").pipe(first()).subscribe(isSaved => {
        if (isSaved) {
          this.savingLand = false;
          this.messageService.add({ severity: 'success', summary: 'Saving', detail: 'Financial records are saved successful.' });
        }
        else {
          this.savingLand = false;
          this.messageService.add({ severity: 'error', summary: 'Error', detail: 'An error occurred while saving!' });
        }
      });
    }
  }

  onImprovementFormSubmit() {
    this.improvementIsSubmitted = true;
    if (this.landForm.valid) {
      this.assignFacility(false, false, true);
      this.facility.status = 'Saved';
      this.facilityService.saveFacility(this.facility, "improvement").pipe(first()).subscribe(isSaved => {
        if (isSaved) {
          this.savingLand = false;
          this.messageService.add({ severity: 'success', summary: 'Saving', detail: 'Improvement records are saved successful.' });
        }
        else {
          this.savingLand = false;
          this.messageService.add({ severity: 'error', summary: 'Error', detail: 'An error occurred while saving!' });
        }
      });
    }
  }

  onLandFormSubmit() {
    this.landIsSubmitted = true;
    if (this.landForm.valid) {
      this.assignFacility(true, false, false);
      this.facility.status = 'Saved';
      this.facilityService.saveFacility(this.facility, "land").pipe(first()).subscribe(facility => {
        if (facility) {
          this.savingLand = false;
          this.facility = facility;
          this.messageService.add({ severity: 'success', summary: 'Saving', detail: 'Land records are saved successful.' });
        }
        else {
          this.savingLand = false;
          this.messageService.add({ severity: 'error', summary: 'Error', detail: 'An error occurred while saving!' });
        }
      });

    }
  }

  onSubmit() {
    this.errorMsg = '';
    this.isSubmitted = true;
    if (this.landForm.invalid && this.improvementForm.invalid && this.financialForm.invalid) {
      this.errorMsg = "Please capture all required information"
      return;
    }
    this.assignFacility(true, true, true);
    this.facility.status = 'Submitted';
    this.facilityService.saveFacility(this.facility, "facility").pipe(first()).subscribe(isSaved => {
      if (isSaved) {
        this.newAsset.emit({ mode: "Add", data: this.facility, response: "isAddedSuccessful" });
        this.savingLand = false;
        this.messageService.add({ severity: 'warn', summary: 'Deleted', detail: 'Asset is added successful.' });
      }
      else {
        this.savingLand = false;
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'An error occurred while adding an asset.' });
      }
    });

  }

  assignFacility(isLandSave: boolean, isFinancialSave: boolean, isImprovementSave: boolean) {
    if (isLandSave) {
      if (this.facility.land != undefined && this.facility.land != null) {
        this.facility.land = {
          id: this.facility.land.id == 0 ? 0 : this.facility.land.id,
          deedsOffice: this.landForm.controls["deedsOffice"].value != undefined ? this.landForm.controls["deedsOffice"].value.name : null,
          type: this.landForm.controls["type"].value != undefined ? this.landForm.controls["type"].value.name : null,
          class: this.landForm.controls["class"].value != undefined ? this.landForm.controls["class"].value.name : null,
          geographicalLocation: {
            id: this.facility.land.geographicalLocation.id == 0 ? 0 : this.facility.land.geographicalLocation.id,
            province: this.landForm.controls["province"].value != undefined ? this.landForm.controls["province"].value.name : null,
            town: this.landForm.controls["town"].value,
            suburb: this.landForm.controls["suburb"].value,
            streetName: this.landForm.controls["streetName"].value,
            streetNumber: Number(this.landForm.controls["streetNumber"].value),
            districtMunicipality: this.landForm.controls["districtMunicipality"].value != undefined ? this.landForm.controls["districtMunicipality"].value.name : null,
            region: this.landForm.controls["region"].value != undefined ? this.landForm.controls["region"].value.name : null,
            localAuthority: this.landForm.controls["localAuthority"].value != undefined ? this.landForm.controls["localAuthority"].value.name : null,
            latitude: this.landForm.controls["latitude"].value,
            longitude: this.landForm.controls["longitude"].value,
            magisterialDistrict: this.landForm.controls["magisterialDistrict"].value != undefined ? this.landForm.controls["magisterialDistrict"].value.name : null,
          },
          propertyDescription: {
            id: this.facility.land.propertyDescription.id == 0 ? 0 : this.facility.land.propertyDescription.id,
            registrationDivision: this.landForm.controls["registrationDivision"].value != undefined ? this.landForm.controls["registrationDivision"].value.name : null,
            townshipName: this.landForm.controls["townshipName"].value,
            landParcel: this.landForm.controls["landParcel"].value,
            landPortion: this.landForm.controls["landPortion"].value,
            oldDescription: this.landForm.controls["oldDescription"].value,
            landRemainder: this.landForm.controls["landRemainder"].value != undefined ? this.landForm.controls["landRemainder"].value.name == "Yes" ? true : false : false,
            farmName: this.landForm.controls["farmName"].value,
            SGDiagramNumber: this.landForm.controls["SGDiagramNumber"].value,
            extent: this.landForm.controls["extent"].value != "" ? Number(this.landForm.controls["extent"].value) : 0,
            LPICode: this.landForm.controls["LPICode"].value,
            acquired: this.landForm.controls["acquired"].value ? this.landForm.controls["acquired"].value.name : null,
            acquiredOther: this.landForm.controls["acquiredOther"].value,
          },
          landUseManagementDetail: {
            id: this.facility.land.landUseManagementDetail.id == 0 ? 0 : this.facility.land.landUseManagementDetail.id,
            titleDeedNumber: this.landForm.controls["titleDeedNumber"].value,
            registrationDate: this.landForm.controls["registrationDate"].value != "" ? this.landForm.controls["registrationDate"].value : null,
            registeredOwner: this.landForm.controls["registeredOwner"].value,
            vestingDate: this.landForm.controls["vestingDate"].value != "" ? this.landForm.controls["vestingDate"].value : null,
            conditionsOfTitle: this.landForm.controls["conditionsOfTitle"].value,
            ownershipCategory: this.landForm.controls["ownershipCategory"].value != undefined ? this.landForm.controls["ownershipCategory"].value.name : null,
            stateOwnedPercentage: this.landForm.controls["stateOwnedPercentage"].value != "" ? this.landForm.controls["stateOwnedPercentage"].value : null,
            landUse: this.landForm.controls["landUse"].value,
            zoning: this.landForm.controls["zoning"].value,
            userDepartment: this.landForm.controls["userDepartment"].value,
            facilityName: this.landForm.controls["facilityName"].value,
            incomeLeaseStatus: this.landForm.controls["incomeLeaseStatus"].value != undefined ? this.landForm.controls["incomeLeaseStatus"].value.name : null,
          },
          leaseStatus: {
            id: this.facility.land.leaseStatus.id == 0 ? 0 : this.facility.land.leaseStatus.id,
            natureOfLease: this.landForm.controls["natureOfLease"].value ? this.landForm.controls["natureOfLease"].value.name : null,
            IDNumberCompanyRegistrationNumber: this.landForm.controls["IDNumberCompanyRegistrationNumber"].value,
            POBox: this.landForm.controls["POBox"].value,
            contactNumber: this.landForm.controls["contactNumber"].value,
            capacityofContactPerson: this.landForm.controls["capacityofContactPerson"].value,
            contactPerson: this.landForm.controls["contactPerson"].value,
            postalCode: Number(this.landForm.controls["postalCode"].value),
            leaseStatusTown: this.landForm.controls["leaseStatusTown"].value,
            rentalAmount: this.landForm.controls["rentalAmount"].value != "" ? this.landForm.controls["rentalAmount"].value : null,
            terminationDate: this.landForm.controls["terminationDate"].value != "" ? this.landForm.controls["terminationDate"].value : null,
            startingDate: this.landForm.controls["startingDate"].value != "" ? this.landForm.controls["startingDate"].value : null,
            occupationDate: this.landForm.controls["occupationDate"].value != "" ? this.landForm.controls["occupationDate"].value : null,
            escalation: this.landForm.controls["escalation"].value,
            vat: this.landForm.controls["vat"].value != undefined ? this.landForm.controls["vat"].value.name : null,
            leaseNumber: this.landForm.controls["leaseNumber"].value != "" ? this.landForm.controls["leaseNumber"].value : null,
            otherCharges: this.landForm.controls["otherCharges"].value != "" ? this.landForm.controls["otherCharges"].value : null,
          }
        };
      }
    }
    if (isFinancialSave) {
      if (this.facility.finance != undefined && this.facility.finance != null) {
        this.facility.finance = {
          id: this.facility.finance.id == 0 ? 0 : this.facility.finance.id,
          landUseClass: this.financialForm.controls["landUseClass"].value,
          natureofAsset: this.financialForm.controls["natureofAsset"].value,
          secondaryInformationNote: {
            id: this.facility.finance.secondaryInformationNote.id == 0 ? 0 : this.facility.finance.secondaryInformationNote.id,
            additionCash: this.financialForm.controls["additionCash"].value != "" ? this.financialForm.controls["additionCash"].value : null,
            additionNonCash: this.financialForm.controls["additionNonCash"].value != "" ? this.financialForm.controls["additionNonCash"].value : null,
            addition: this.financialForm.controls["addition"].value != "" ? this.financialForm.controls["addition"].value : null,
            disposal: this.financialForm.controls["disposal"].value != "" ? this.financialForm.controls["disposal"].value : null,
            closingBalance: this.financialForm.controls["closingBalance"].value != "" ? this.financialForm.controls["closingBalance"].value : null,
          },
          valuation: {
            id: this.facility.finance.valuation.id == 0 ? 0 : this.facility.finance.valuation.id,
            municipalValuationDate: this.financialForm.controls["municipalValuationDate"].value != "" ?  this.financialForm.controls["municipalValuationDate"].value : null,
            nonMunicipalValuationDate:  this.financialForm.controls["nonMunicipalValuationDate"].value != "" ? this.financialForm.controls["nonMunicipalValuationDate"].value : null,
            municipalValuation: this.financialForm.controls["municipalValuation"].value,
            nonMunicipalValuation: this.financialForm.controls["nonMunicipalValuation"].value,
            propetyRatesAccount: this.financialForm.controls["propetyRatesAccount"].value,
            value: this.financialForm.controls["value"].value,
            accountNoForService: this.financialForm.controls["accountNoForService"].value,
            personInstitutionResposible: this.financialForm.controls["personInstitutionResposible"].value,
          }
        }
      }
    }
    if (isImprovementSave) {
      if (this.facility.improvements != undefined && this.facility.improvements != null) {
        this.facility.improvements = this.improvements;
      }
    }
  }

  buildForm() {
    this.landForm = this.formBuilder.group({
      deedsOffice: [''],
      class: [''],
      type: [''],
      province: [''],
      town: [''],
      suburb: [''],
      streetName: [''],
      streetNumber: [''],
      districtMunicipality: [''],
      region: [''],
      localAuthority: [''],
      latitude: [''],
      longitude: [''],
      registrationDivision: [''],
      townshipName: [''],
      landParcel: [''],
      landPortion: [''],
      oldDescription: [''],
      landRemainder: [''],
      farmName: [''],
      SGDiagramNumber: [''],
      extent: [''],
      LPICode: [''],
      acquired: [''],
      acquiredOther: [''],
      titleDeedNumber: [''],
      registrationDate: [''],
      registeredOwner: [''],
      vestingDate: [''],
      conditionsOfTitle: [''],
      ownershipCategory: [''],
      stateOwnedPercentage: [''],
      landUse: [''],
      zoning: [''],
      userDepartment: [''],
      facilityName: [''],
      incomeLeaseStatus: [''],
      vat: [''],
      leaseNumber: [''],
      otherCharges: [''],
      rentalAmount: [''],
      terminationDate: [''],
      startingDate: [''],
      occupationDate: [''],
      escalation: [''],
      contactNumber: [''],
      capacityofContactPerson: [''],
      contactPerson: [''],
      postalCode: [''],
      leaseStatusTown: [''],
      POBox: [''],
      IDNumberCompanyRegistrationNumber: [''],
      natureOfLease: [''],
      magisterialDistrict: ['']
    });
    this.improvementForm = this.formBuilder.group({
      buildingName: ['', Validators.required],
      type: ['', Validators.required],
      size: ['', [Validators.required]],
      potentialUse: ['', [Validators.required]],
      siteCoverag: ['', [Validators.required]],
      levelofUtilization: ['', [Validators.required]],
      extentofBuilding: ['', [Validators.required]],
      conditionRating: ['', [Validators.required]],
      usableArea: ['', [Validators.required]],
      functionalPerformanceRating: ['', [Validators.required]],
      comment: ['', [Validators.required]],
    });
    this.financialForm = this.formBuilder.group({
      landUseClass: [''],
      natureofAsset: [''],
      additionCash: [''],
      additionNonCash: [''],
      addition: [''],
      disposal: [''],
      closingBalance: [''],
      municipalValuationDate: [''],
      nonMunicipalValuationDate: [''],
      municipalValuation: [''],
      nonMunicipalValuation: [''],
      propetyRatesAccount: [''],
      value: [''],
      accountNoForService: [''],
      personInstitutionResposible: [''],
    });

    this.magisterialDistricts = [
      { name: 'Chief Albert Luthuli', code: 'CAL', factor: 1 },
      { name: 'Bushbuckridge', code: 'BB', factor: 2 },
      { name: 'Bohlabela', code: 'B', factor: 3 },
      { name: 'Dipaleseng', code: 'D', factor: 4 },
      { name: 'Dr JS Moroka', code: 'JSM', factor: 5 },
      { name: 'Emakhazeni ', code: 'EK', factor: 6 },
      { name: 'Emalahleni', code: 'E', factor: 7 },
      { name: 'Govan Mbeki', code: 'GM', factor: 8 },
      { name: 'Lekwa ', code: 'L', factor: 9 },
      { name: 'Mbombela', code: 'M', factor: 10 },
      { name: 'Mkhondo', code: 'MK', factor: 11 },
      { name: 'Msukaligwa', code: 'MS', factor: 12 },
      { name: 'Nkomazi', code: 'N', factor: 13 },
      { name: 'Dr Pixley ka Seme', code: 'PKS', factor: 14 },
      { name: 'Steve Tshwete', code: 'ST', factor: 15 },
      { name: 'Thaba Chweu', code: 'TC', factor: 16 },
      { name: 'Thembisile Hani', code: 'TH', factor: 17 },
      { name: 'Victor Khanye ', code: 'VK', factor: 18 },
      { name: 'Umjindi ', code: 'U', factor: 19 }
    ];

    this.buttonItems = [
      {
        label: 'Update', icon: 'pi pi-pencil', command: () =>
          this.editImprovement()
      },
      { separator: true },
      {
        label: 'Delete', icon: 'pi pi-trash', command: () =>
          this.confirmDelete()
      }
    ];
    this.steps = [
      { label: 'Land', icon: 'pi pi-fw pi-globe' },
      { label: 'Finane', icon: 'pi pi-fw pi-money-bill' },
      { label: 'Impronements', icon: 'pi pi-fw pi-home' }
    ];

    this.potentialUseList = [
      { name: 'School', code: 'S', factor: 1 },
      { name: 'Farm', code: 'F', factor: 2 },
      { name: 'House', code: 'H', factor: 3 }];

    this.typeOfImprovements = [
      { name: 'Hotel', code: 'H', factor: 1 },
      { name: 'House', code: 'HH', factor: 2 }];

    this.activeItem = this.steps[0];

    this.userDepartments = [
      { name: 'Agriculture, rural development, land & environmental affairs', code: 'ARALEA', factor: 1 },
      { name: 'Economic development & tourism', code: 'EDT', factor: 2 },
      { name: 'Co-operative governance & traditional affairs', code: 'CGTA', factor: 3 },
      { name: 'Community safety, security & liason', code: 'CSSL', factor: 4 },
      { name: 'Culture, sport & recreation', code: 'CSR', factor: 5 },
      { name: 'Education', code: 'E', factor: 6 },
      { name: 'Provincial treasury', code: 'PT', factor: 7 },
      { name: 'Health', code: 'H', factor: 8 },
      { name: 'Human settlements', code: 'HS', factor: 9 },
      { name: 'Social development', code: 'SD', factor: 10 },
      { name: 'Publick works, roads & transport', code: 'PWRT', factor: 11 },
    ];
    this.registrationDivisions = [
      { name: 'Bloemfontein', code: 'B', factor: 1 },
      { name: 'Johannesburg', code: 'J', factor: 2 },
      { name: 'King Williams town', code: 'KWT', factor: 3 },
      { name: 'Mpumalanga', code: 'M', factor: 4 },
      { name: 'Pretoria ', code: 'P', factor: 5 },
      { name: 'Cape town', code: 'CT', factor: 6 },
      { name: 'Kimberly', code: 'K', factor: 7 },
      { name: 'Limpopo', code: 'L', factor: 8 },
      { name: 'Pietermaritzburg', code: 'P', factor: 9 },
      { name: 'Umtata', code: 'U', factor: 10 },
      { name: 'Vryburg', code: 'V', factor: 11 },
    ];

    this.ownershipCategories = [
      { name: 'State-Owned', code: 'SO', factor: 1 },
      { name: 'Non-State Owned', code: 'NSO', factor: 2 },
    ];
    this.classes = [
      { name: 'Urban', code: 'U', factor: 1 },
      { name: 'Rural', code: 'R', factor: 2 },
    ];
    this.types = [
      { name: 'Erf', code: 'E', factor: 1 },
      { name: 'Farm', code: 'F', factor: 2 },
      { name: 'Agricultural Holding', code: 'A', factor: 3 },
      { name: 'Sectional Title', code: 'S', factor: 4 }
    ];
    this.deedsOffices = [
      { name: 'Head Office', code: 'H', factor: 1 },
      { name: 'Bloemfontein', code: 'B', factor: 2 },
      { name: 'Cape Town', code: 'CT', factor: 3 },
      { name: 'Johannesburg', code: 'J', factor: 4 },
      { name: 'Kimberly', code: 'K', factor: 5 },
      { name: 'King Williams Town', code: 'K', factor: 6 },
      { name: 'Limpopo', code: 'B', factor: 2 },
      { name: 'Mpumalanga', code: 'CT', factor: 3 },
      { name: 'Pietermaritzburg', code: 'J', factor: 4 },
      { name: 'Pretoria', code: 'K', factor: 5 },
      { name: 'Umtata', code: 'K', factor: 6 },
      { name: 'Vryburg', code: 'K', factor: 6 },
    ];
    this.provinces = [
      { name: 'Eastern Cape', code: 'EC', factor: 1 },
      { name: 'Free State', code: 'FS', factor: 2 },
      { name: 'Gauteng', code: 'G', factor: 3 },
      { name: 'Kwazulu Natal', code: 'KZN', factor: 4 },
      { name: 'Limpopo', code: 'L', factor: 5 },
      { name: 'Mpumalanga', code: 'MP', factor: 6 },
      { name: 'Northern Cape', code: 'NC', factor: 7 },
      { name: 'North West', code: 'NW', factor: 8 },
      { name: 'Western Cape', code: 'WC', factor: 9 }
    ];

    this.districtMunicipalities = [
      { name: 'Ehlanzeni District Municipality', code: 'E', factor: 1 },
      { name: 'Gert Sibande District Municipality', code: 'G', factor: 2 },
      { name: 'Nkangala District Municipality', code: 'N', factor: 3 }
    ];

    this.landRemainders = [
      { name: 'Yes ', code: 'Y', factor: 1 },
      { name: 'No', code: 'N', factor: 2 },
    ];

    this.vats = [
      { name: 'Incl', code: 'I', factor: 1 },
      { name: 'Excl', code: 'E', factor: 2 },
    ];

    this.functionalPerformanceRatings = [
      { name: '1 - The asset standards exceeds the level expected for functional and operational requirements', code: '1', factor: 1 },
      { name: '2 - Functional Performance meets the standards expected for functional and operational requirements', code: '2', factor: 2 },
      { name: '3 -Functional Performance does not meet the standard expected for functional and operational requirements', code: '3', factor: 3 }
    ];

    this.howAcquireds = [
      { name: 'Purchased', code: 'P', factor: 1 },
      { name: 'Expropriated', code: 'E', factor: 2 },
      { name: 'Donation', code: 'D', factor: 3 },
      { name: 'Exchanged', code: 'EX', factor: 4 },
      { name: 'Revision', code: 'R', factor: 5 },
      { name: 'Repossession', code: 'RP', factor: 6 },
      { name: 'Prescription', code: 'PS', factor: 7 },
      { name: 'Lease Contract', code: 'LC', factor: 8 },
      { name: 'Inherited', code: 'I', factor: 9 },
      { name: 'Other', code: 'O', factor: 10 }
    ];
    this.regions = [
      { name: 'Ehlanzeni ', code: 'U', factor: 1 },
      { name: 'Gert Sibande', code: 'R', factor: 2 },
      { name: 'Nkangala', code: 'U', factor: 3 }
    ];

    this.conditionRatings = [
      { name: 'C1 (Very Poor)', code: 'C1', factor: 1 },
      { name: 'C2 (Poor)', code: 'C2', factor: 2 },
      { name: 'C3 (Fair)', code: 'C3', factor: 3 },
      { name: 'C4 (Good)', code: 'C4', factor: 4 },
      { name: 'C5 (Excellent)', code: 'C5', factor: 5 },
    ];

    this.incomeLeaseStatuses = [
      { name: 'Yes', code: 'Y', factor: 1 },
      { name: 'No', code: 'N', factor: 2 }
    ];

    this.natureOfLeases = [
      { name: 'Residential', code: 'R', factor: 1 },
      { name: 'Business', code: 'B', factor: 2 }
    ];
  }

  showToast(summary: string, detail: string) {
    this.messageService.add({ severity: 'success', summary: summary, detail: detail });
  }

  initFacility() {
    this.improvements = this.facility.improvements;
    if (this.facility.land == undefined) {
      this.facility.land = { id: 0 }
    }
    if (this.facility.land.geographicalLocation == undefined) {
      this.facility.land.geographicalLocation = { id: 0 }
    }

    if (this.facility.land.geographicalLocation == undefined) {
      this.facility.land.propertyDescription = { id: 0 }
    }

    if (this.facility.land.landUseManagementDetail == undefined) {
      this.facility.land.landUseManagementDetail = { id: 0 }
    }
    if (this.facility.land.leaseStatus == undefined) {
      this.facility.land.leaseStatus = { id: 0 }
    }

    if (this.facility.finance == undefined) {
      this.facility.finance = { id: 0 }
    }
    if (this.facility.finance.secondaryInformationNote == undefined) {
      this.facility.finance.secondaryInformationNote = { id: 0 }
    }
    if (this.facility.finance.valuation == undefined) {
      this.facility.finance.valuation = { id: 0 }
    }

    let deedsOffice = this.deedsOffices.filter(d => d.name.toLowerCase().trim() == (this.facility.land.deedsOffice != undefined ? this.facility.land.deedsOffice.toLowerCase().trim() : this.facility.land.deedsOffice))[0];
    let type = this.types.filter(d => d.name.toLowerCase().trim() == (this.facility.land.type != undefined ? this.facility.land.type.toLowerCase().trim() : this.facility.land.type))[0];
    let assetClass = this.classes.filter(d => d.name.toLowerCase().trim() == (this.facility.land.class != undefined ? this.facility.land.class.toLowerCase().trim() : this.facility.land.class))[0];
    let province = this.provinces.filter(d => d.name.toLowerCase().trim() == (this.facility.land.geographicalLocation.province != undefined ? this.facility.land.geographicalLocation.province.toLowerCase().trim() : this.facility.land.geographicalLocation.province))[0];
    let districtMunicipality = this.districtMunicipalities.filter(d => d.name.toLowerCase().trim() == (this.facility.land.geographicalLocation.districtMunicipality != undefined ? this.facility.land.geographicalLocation.districtMunicipality.toLowerCase().trim() : this.facility.land.geographicalLocation.districtMunicipality))[0];

    let region = this.regions.filter(d => d.name.toLowerCase().trim() == (this.facility.land.region != undefined ? this.facility.land.region.toLowerCase().trim() : this.facility.land.region))[0];
    let registrationDivision = this.registrationDivisions.filter(d => d.name.toLowerCase().trim() == (this.facility.land.propertyDescription.registrationDivision != undefined ? this.facility.land.propertyDescription.registrationDivision.toLowerCase().trim() : this.facility.land.propertyDescription.registrationDivision))[0];
    let landRemainder = this.landRemainders.filter(d => d.name == (this.facility.land.propertyDescription.landRemainder == false ? 'No' : 'Yes'))[0];
    let acquired = this.howAcquireds.filter(d => d.name.toLowerCase().trim() == (this.facility.land.propertyDescription.acquired != undefined ? this.facility.land.propertyDescription.acquired.toLowerCase().trim() : this.facility.land.propertyDescription.acquired))[0];
    let ownershipCategory = this.ownershipCategories.filter(d => d.name.toLowerCase().trim() == (this.facility.land.landUseManagementDetail.ownershipCategory != undefined ? this.facility.land.landUseManagementDetail.ownershipCategory.toLowerCase().trim() : this.facility.land.landUseManagementDetail.ownershipCategory))[0];
    let userDepartment = this.userDepartments.filter(d => d.name.toLowerCase().trim() == (this.facility.land.landUseManagementDetail.userDepartment != undefined ? this.facility.land.landUseManagementDetail.userDepartment.toLowerCase().trim() : this.facility.land.landUseManagementDetail.userDepartment))[0];
    let incomeLeaseStatus = this.incomeLeaseStatuses.filter(d => d.name.toLowerCase().trim() == (this.facility.land.landUseManagementDetail.incomeLeaseStatus != undefined ? this.facility.land.landUseManagementDetail.incomeLeaseStatus.toLowerCase().trim() : this.facility.land.landUseManagementDetail.incomeLeaseStatus))[0];
    let natureOfLease = this.natureOfLeases.filter(d => d.name.toLowerCase().trim() == (this.facility.land.leaseStatus.natureOfLease != undefined ? this.facility.land.leaseStatus.natureOfLease.toLowerCase().trim() : this.facility.land.leaseStatus.natureOfLease))[0];
    let vat = this.vats.filter(d => d.name == this.facility.land.leaseStatus.vat)[0];
    let _districtMunicipality = {
      value: districtMunicipality
    };
    this.setDistrictMunicipality(_districtMunicipality);
    let localAuthority = undefined;// this.localAuthorities.filter(d => d.name.toLowerCase().trim() == (_districtMunicipality.value != undefined ? this.facility.land.geographicalLocation.localAuthority.toLowerCase().trim()  : this.facility.land.geographicalLocation.localAuthority))[0];

    this.landForm = this.formBuilder.group({
      deedsOffice: [deedsOffice],
      class: [assetClass],
      type: [type],
      province: [province],
      town: [this.facility.land.geographicalLocation.town],
      suburb: [this.facility.land.geographicalLocation.suburb],
      streetName: [this.facility.land.geographicalLocation.streetName],
      streetNumber: [this.facility.land.geographicalLocation.streetNumber],
      districtMunicipality: [districtMunicipality],
      region: [region],
      localAuthority: [localAuthority],
      latitude: [this.facility.land.geographicalLocation.latitude],
      longitude: [this.facility.land.geographicalLocation.longitude],
      magisterialDistrict: [this.facility.land.propertyDescription.magisterialDistrict],
      registrationDivision: [registrationDivision],
      townshipName: [this.facility.land.propertyDescription.townshipName],
      landParcel: [this.facility.land.propertyDescription.landParcel],
      landPortion: [this.facility.land.propertyDescription.landPortion],
      oldDescription: [this.facility.land.propertyDescription.oldDescription],
      landRemainder: [landRemainder],
      farmName: [this.facility.land.propertyDescription.farmName],
      SGDiagramNumber: [this.facility.land.propertyDescription.sGDiagramNumber],
      extent: [this.facility.land.propertyDescription.extent],
      LPICode: [this.facility.land.propertyDescription.lPICode],
      acquired: [acquired],
      acquiredOther: [this.facility.land.propertyDescription.acquiredOther],
      titleDeedNumber: [this.facility.land.landUseManagementDetail.titleDeedNumber],
      registrationDate: [this.facility.land.landUseManagementDetail.registrationDate != undefined ? new Date(this.facility.land.landUseManagementDetail.registrationDate) : new Date()],
      registeredOwner: [this.facility.land.landUseManagementDetail.registeredOwner],
      vestingDate: [this.facility.land.landUseManagementDetail.vestingDate],
      conditionsOfTitle: [this.facility.land.landUseManagementDetail.conditionsOfTitle],
      ownershipCategory: [ownershipCategory],
      stateOwnedPercentage: [this.facility.land.landUseManagementDetail.stateOwnedPercentage],
      landUse: [this.facility.land.landUseManagementDetail.landUse],
      zoning: [this.facility.land.landUseManagementDetail.zoning],
      userDepartment: [this.facility.land.landUseManagementDetail.userDepartment],
      facilityName: [this.facility.land.landUseManagementDetail.facilityName],
      incomeLeaseStatus: [incomeLeaseStatus],
      leaseNumber: [this.facility.land.leaseStatus.leaseNumber],
      otherCharges: [this.facility.land.leaseStatus.otherCharges],
      rentalAmount: [this.facility.land.leaseStatus.rentalAmount],
      terminationDate: [this.facility.land.leaseStatus.terminationDate != undefined ? new Date(this.facility.land.leaseStatus.terminationDate) : new Date()],
      startingDate: [this.facility.land.leaseStatus.startingDate != undefined ? new Date(this.facility.land.leaseStatus.startingDate) : new Date()],
      occupationDate: [this.facility.land.leaseStatus.occupationDate != undefined ? new Date(this.facility.land.leaseStatus.occupationDate) : new Date()],
      escalation: [this.facility.land.leaseStatus.escalation],
      contactNumber: [this.facility.land.leaseStatus.contactNumber],
      capacityofContactPerson: [this.facility.land.leaseStatus.capacityofContactPerson],
      contactPerson: [this.facility.land.leaseStatus.contactPerson],
      postalCode: [this.facility.land.leaseStatus.postalCode],
      leaseStatusTown: [this.facility.land.leaseStatus.leaseStatusTown],
      POBox: [this.facility.land.leaseStatus.pOBox],
      IDNumberCompanyRegistrationNumber: [this.facility.land.leaseStatus.IDNumberCompanyRegistrationNumber],
      natureOfLease: [natureOfLease],
      vat: [vat],
    });
    this.improvementForm = this.formBuilder.group({
      buildingName: ['', Validators.required],
      type: ['', Validators.required],
      size: ['', [Validators.required]],
      potentialUse: ['', [Validators.required]],
      siteCoverag: ['', [Validators.required]],
      levelofUtilization: ['', [Validators.required]],
      extentofBuilding: ['', [Validators.required]],
      conditionRating: ['', [Validators.required]],
      usableArea: ['', [Validators.required]],
      functionalPerformanceRating: ['', [Validators.required]],
      comment: ['', [Validators.required]],
    });
    this.financialForm = this.formBuilder.group({
      landUseClass: [this.facility.finance.landUseClass],
      natureofAsset: [this.facility.finance.natureofAsset],
      additionCash: [this.facility.finance.secondaryInformationNote.additionCash],
      additionNonCash: [this.facility.finance.secondaryInformationNote.additionNonCash],
      addition: [this.facility.finance.secondaryInformationNote.addition],
      disposal: [this.facility.finance.secondaryInformationNote.disposal],
      closingBalance: [this.facility.finance.secondaryInformationNote.closingBalance],
      municipalValuationDate: [this.facility.finance.valuation.municipalValuationDate],
      nonMunicipalValuationDate: [this.facility.finance.valuation.nonMunicipalValuationDate],
      municipalValuation: [this.facility.finance.valuation.municipalValuation],
      nonMunicipalValuation: [this.facility.finance.valuation.nonMunicipalValuation],
      propetyRatesAccount: [this.facility.finance.valuation.propetyRatesAccount],
      value: [this.facility.finance.valuation.value],
      accountNoForService: [this.facility.finance.valuation.accountNoForService],
      personInstitutionResposible: [this.facility.finance.valuation.personInstitutionResposible],
    });
  }

  confirmDelete() {
    this.improvements.splice(this.selectedImprovement);
  }

  editImprovement() {
    this.improvementForm = this.formBuilder.group({
      buildingName: [this.selectedImprovement.buildingName, Validators.required],
      typeOfImprovement: [this.selectedImprovement.typeOfImprovement, Validators.required],
      sizeofImprovement: [this.selectedImprovement.sizeofImprovement, [Validators.required]],
      potentialUse: [this.selectedImprovement.potentialUse, [Validators.required]],
      town: [this.selectedImprovement.town, [Validators.required]],
      suburb: [this.selectedImprovement.suburb, [Validators.required]],
      streetName: [this.selectedImprovement.streetName, [Validators.required]],
      streetNumber: [this.selectedImprovement.streetNumber, [Validators.required]],
      siteCoverag: [this.selectedImprovement.siteCoverag, [Validators.required]],
      functionalPerformanceRating: [this.selectedImprovement.functionalPerformanceRating, [Validators.required]],
      extentofBuilding: [this.selectedImprovement.extentofBuilding, [Validators.required]],
      conditionRating: [this.selectedImprovement.conditionRating, [Validators.required]],
      usableArea: [this.selectedImprovement.usableArea, [Validators.required]],
    });
  }

  selectImprovement(improvement) {
    this.selectedImprovement = improvement;
  }

  AddImprovement() {
    if (this.improvementForm.valid) {
      let improvement = {
        id: 0,
        buildingName: this.improvementForm.controls["buildingName"].value,
        type: this.improvementForm.controls["type"].value != undefined ? this.improvementForm.controls["type"].value.name : null,
        size: this.improvementForm.controls["size"].value,
        potentialUse: this.improvementForm.controls["potentialUse"].value != undefined ? this.improvementForm.controls["potentialUse"].value.name : null,
        siteCoverag: this.improvementForm.controls["siteCoverag"].value != "" ? this.improvementForm.controls["siteCoverag"].value.toString() : null,
        levelofUtilization: this.improvementForm.controls["levelofUtilization"].value != "" ? this.improvementForm.controls["levelofUtilization"].value.toString() : null,
        extentofBuilding: this.improvementForm.controls["extentofBuilding"].value != "" ? this.improvementForm.controls["extentofBuilding"].value.toString() : null,
        conditionRating: this.improvementForm.controls["conditionRating"].value != undefined ? this.improvementForm.controls["conditionRating"].value.name: null,
        usableArea: this.improvementForm.controls["usableArea"].value != "" ? this.improvementForm.controls["usableArea"].value.toString() : null,
        functionalPerformanceRating: this.improvementForm.controls["functionalPerformanceRating"].value != undefined ? this.improvementForm.controls["functionalPerformanceRating"].value.name : null,
        comment: this.improvementForm.controls["comment"].value,
      };
      this.improvements.push(improvement);
    }
  }

  makeId(length) {
    var result = '';
    var characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
    var charactersLength = characters.length;
    for (var i = 0; i < length; i++) {
      result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }
    return result;
  }
}
