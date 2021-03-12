import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MenuItem, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/internal/operators/first';
import { Facility } from 'src/app/models/facility.model';
import { FacilityService } from 'src/app/services/facility/facility.service';
import { ConfirmationService } from 'primeng/api';

@Component({
  selector: 'app-addassetregister',
  templateUrl: './addassetregister.component.html',
  styleUrls: ['./addassetregister.component.css'],
  providers: [ConfirmationService]
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
  howAcquired: any[];
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

  financial: {};
  improvement: {}

  constructor(private confirmationService: ConfirmationService, public facilityService: FacilityService, private formBuilder: FormBuilder, private messageService: MessageService) { }

  ngOnInit() {
    this.buildForm();
    if (this.selectedAsset.facilityId != undefined) {
      this.mode = this.selectedAsset.mode;
      this.facilityService.getFacilityById(this.selectedAsset.facilityId, this.selectedAsset.facilityType).pipe(first()).subscribe(facility => {
        this.loading = false;
        this.facility = facility;
        this.initFacility();
      });
    } else {
      this.mode = this.selectedAsset.mode;
      this.loading = false;
    }

    this.facility = {
      id: 0,
      name: '',
      fileReference: '',
      facilityType: '',
      clientCode: '',
      vestingInformation: '',
      comments: '',
      userId: 0,
      status: "1",
      createdBy: '',
      createdDate: new Date(),
      modifiedBy: '',
      modifiedDate: new Date(),   
      land: {},
      financial: {},  
      improvements: []
    }
  }

  get l() { return this.landForm.controls; }
  get f() { return this.financialForm.controls; }
  get I() { return this.improvementForm.controls; }

  setLocalAuthorities(e) { }

  setDistrictMunicipality(e) {
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
      this.assignFacility(false, false, true);
    }
  }

  onImprovementFormSubmit() {
    this.improvementIsSubmitted = true;
    if (this.landForm.valid) {
      this.assignFacility(false, true, false);
    }
  }

  onLandFormSubmit() {
    this.landIsSubmitted = true;
    if (this.landForm.valid) {
      this.assignFacility(true, false, false);
      this.facilityService.saveFacility(this.facility, 0).pipe(first()).subscribe(isSaved => {
        if (isSaved) {
          this.savingLand = false;
          this.messageService.add({ severity: 'warn', summary: 'Deleted', detail: 'Asset is deleted successful.' });
        }
        else {
          this.savingLand = false;
          this.messageService.add({ severity: 'error', summary: 'Error', detail: 'An error occurred while delete asset.' });
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
    this.facilityService.saveFacility(this.facility, 2).pipe(first()).subscribe(isSaved => {
      if (isSaved) {
        this.newAsset.emit({ mode: "Add", data: this.facility, response: "isUpdatedSuccessful" });
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
          id: 0,
          deedOffice: this.landForm.controls["deedsOffice"].value.name,
          type: this.landForm.controls["type"].value,
          class: this.landForm.controls["class"].value,
          geographicalLocation: {
            id: 0,
            province: this.landForm.controls["province"].value.name,
            town: this.landForm.controls["town"].value,
            suburb: this.landForm.controls["suburb"].value,
            streetName: this.landForm.controls["streetName"].value,
            streetNumber: this.landForm.controls["streetNumber"].value,
            districtMunicipality: this.landForm.controls["districtMunicipality"].value,
            region: this.landForm.controls["region"].value,
            localAuthority: this.landForm.controls["localAuthority"].value,
            latitude: this.landForm.controls["latitude"].value,
            longitude: this.landForm.controls["longitude"].value,
            magisterialDistrict: this.landForm.controls["magisterialDistrict"].value,
          },
          propertyDescription: {
            id: 0,
            registrationDivision: this.landForm.controls["registrationDivision"].value,
            townshipName: this.landForm.controls["townshipName"].value,
            landParcel: this.landForm.controls["landParcel"].value,
            landPortion: this.landForm.controls["landPortion"].value,
            oldDescription: this.landForm.controls["oldDescription"].value,
            landRemainder: this.landForm.controls["landRemainder"].value,
            farmName: this.landForm.controls["farmName"].value,
            SGDiagramNumber: this.landForm.controls["SGDiagramNumber"].value,
            extent: this.landForm.controls["extent"].value,
            LPICode: this.landForm.controls["LPICode"].value,
            acquired: this.landForm.controls["acquired"].value,
            acquiredOther: this.landForm.controls["acquiredOther"].value,
          },
          landUseManagementDetail: {
            id: 0,
            titleDeedNumber: this.landForm.controls["titleDeedNumber"].value,
            registrationDate: this.landForm.controls["registrationDate"].value,
            registeredOwner: this.landForm.controls["registeredOwner"].value,
            vestingDate: this.landForm.controls["vestingDate"].value,
            conditionsOfTitle: this.landForm.controls["conditionsOfTitle"].value,
            ownershipCategory: this.landForm.controls["ownershipCategory"].value,
            stateOwnedPercentage: this.landForm.controls["stateOwnedPercentage"].value,
            landUse: this.landForm.controls["landUse"].value,
            zoning: this.landForm.controls["zoning"].value,
            userDepartment: this.landForm.controls["userDepartment"].value,
            facilityName: this.landForm.controls["facilityName"].value,
            incomeLeaseStatus: this.landForm.controls["incomeLeaseStatus"].value,
          },
          leaseStatus: {
            id: 0,
            natureOfLease: this.landForm.controls["natureOfLease"].value,
            IDNumberCompanyRegistrationNumber: this.landForm.controls["IDNumberCompanyRegistrationNumber"].value,
            POBox: this.landForm.controls["POBox"].value,
            contactNumber: this.landForm.controls["contactNumber"].value,
            capacityofContactPerson: this.landForm.controls["capacityofContactPerson"].value,
            contactPerson: this.landForm.controls["contactPerson"].value,
            postalCode: this.landForm.controls["postalCode"].value,
            leaseStatusTown: this.landForm.controls["leaseStatusTown"].value,
            rentalAmount: this.landForm.controls["rentalAmount"].value,
            terminationDate: this.landForm.controls["terminationDate"].value,
            startingDate: this.landForm.controls["startingDate"].value,
            occupationDate: this.landForm.controls["occupationDate"].value,
            escalation: this.landForm.controls["escalation"].value,
            vat: this.landForm.controls["vat"].value,
            leaseNumber: this.landForm.controls["leaseNumber"].value,
            otherCharges: this.landForm.controls["otherCharges"].value,
          }
        };
      }
    }
    if (isFinancialSave) {
      if (this.facility.financial != undefined && this.facility.financial != null) {
        this.facility.financial = {
          id: 0,
          landUseClass: this.financialForm.controls["landUseClass"].value,
          natureofAsset: this.financialForm.controls["natureofAsset"].value,
          secondaryInformationNote: {
            additionCash: this.financialForm.controls["additionCash"].value,
            additionNonCash: this.financialForm.controls["additionNonCash"].value,
            addition: this.financialForm.controls["addition"].value,
            disposal: this.financialForm.controls["disposal"].value,
            closingBalance: this.financialForm.controls["closingBalance"].value,
          },
          valuation: {
            dateofMunicipalValuation: this.financialForm.controls["dateofMunicipalValuation"].value,
            dateofNonMunicipalValuation: this.financialForm.controls["dateofNonMunicipalValuation"].value,
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
      deedsOffice: ['', Validators.required],
      class: ['', Validators.required],
      type: ['', [Validators.required]],
      province: ['', [Validators.required]],
      town: ['', [Validators.required]],
      suburb: ['', [Validators.required]],
      streetName: ['', [Validators.required]],
      streetNumber: ['', [Validators.required]],
      districtMunicipality: ['', [Validators.required]],
      region: ['', [Validators.required]],
      localAuthority: ['', [Validators.required]],
      latitude: ['', [Validators.required]],
      longitude: ['', [Validators.required]],
      registrationDivision: ['', [Validators.required]],
      townshipName: ['', [Validators.required]],
      landParcel: ['', [Validators.required]],
      landPortion: ['', [Validators.required]],
      oldDescription: ['', [Validators.required]],
      landRemainder: ['', [Validators.required]],
      farmName: ['', [Validators.required]],
      SGDiagramNumber: ['', [Validators.required]],
      extent: ['', [Validators.required]],
      LPICode: ['', [Validators.required]],
      acquired: ['', [Validators.required]],
      acquiredOther: [''],
      titleDeedNumber: ['', [Validators.required]],
      registrationDate: ['', [Validators.required]],
      registeredOwner: ['', [Validators.required]],
      vestingDate: ['', [Validators.required]],
      conditionsOfTitle: ['', [Validators.required]],
      ownershipCategory: ['', [Validators.required]],
      stateOwnedPercentage: ['', [Validators.required]],
      landUse: ['', [Validators.required]],
      zoning: ['', [Validators.required]],
      userDepartment: ['', [Validators.required]],
      facilityName: ['', [Validators.required]],
      incomeLeaseStatus: ['', [Validators.required]],
      vat: ['', [Validators.required]],
      leaseNumber: ['', [Validators.required]],
      otherCharges: ['', [Validators.required]],
      rentalAmount: ['', [Validators.required]],
      terminationDate: ['', [Validators.required]],
      startingDate: ['', [Validators.required]],
      occupationDate: ['', [Validators.required]],
      escalation: ['', [Validators.required]],
      contactNumber: ['', [Validators.required]],
      capacityofContactPerson: ['', [Validators.required]],
      contactPerson: ['', [Validators.required]],
      postalCode: ['', [Validators.required]],
      leaseStatusTown: ['', [Validators.required]],
      POBox: ['', [Validators.required]],
      IDNumberCompanyRegistrationNumber: ['', [Validators.required]],
      natureOfLease: ['', [Validators.required]],
      magisterialDistrict: ['', [Validators.required]]
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
      landUseClass: ['', Validators.required],
      natureofAsset: ['', Validators.required],
      additionCash: ['', [Validators.required]],
      additionNonCash: ['', [Validators.required]],
      addition: ['', [Validators.required]],
      disposal: ['', [Validators.required]],
      closingBalance: ['', [Validators.required]],
      dateofMunicipalValuation: ['', [Validators.required]],
      dateofNonMunicipalValuation: ['', [Validators.required]],
      municipalValuation: ['', [Validators.required]],
      nonMunicipalValuation: ['', [Validators.required]],
      propetyRatesAccount: ['', [Validators.required]],
      value: ['', [Validators.required]],
      accountNoForService: ['', [Validators.required]],
      personInstitutionResposible: ['', [Validators.required]],
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
      { label: 'Financials', icon: 'pi pi-fw pi-money-bill' },
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

    this.howAcquired = [
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

    this.landForm = this.formBuilder.group({
      deedsOffice: ['', Validators.required],
      class: ['', Validators.required],
      type: ['', [Validators.required]],
      province: ['', [Validators.required]],
      town: ['', [Validators.required]],
      suburb: ['', [Validators.required]],
      streetName: ['', [Validators.required]],
      streetNumber: ['', [Validators.required]],
      districtMunicipality: ['', [Validators.required]],
      region: ['', [Validators.required]],
      localAuthority: ['', [Validators.required]],
      latitude: ['', [Validators.required]],
      longitude: ['', [Validators.required]],
      registrationDivision: ['', [Validators.required]],
      townshipName: ['', [Validators.required]],
      landParcel: ['', [Validators.required]],
      landPortion: ['', [Validators.required]],
      oldDescription: ['', [Validators.required]],
      landRemainder: ['', [Validators.required]],
      farmName: ['', [Validators.required]],
      SGDiagramNumber: ['', [Validators.required]],
      extent: ['', [Validators.required]],
      LPICode: ['', [Validators.required]],
      acquired: ['', [Validators.required]],
      acquiredOther: ['', [Validators.required]],
      titleDeedNumber: ['', [Validators.required]],
      registrationDate: ['', [Validators.required]],
      registeredOwner: ['', [Validators.required]],
      vestingDate: ['', [Validators.required]],
      conditionsOfTitle: ['', [Validators.required]],
      ownershipCategory: ['', [Validators.required]],
      stateOwnedPercentage: ['', [Validators.required]],
      landUse: ['', [Validators.required]],
      zoning: ['', [Validators.required]],
      userDepartment: ['', [Validators.required]],
      facilityName: ['', [Validators.required]],
      incomeLeaseStatus: ['', [Validators.required]],
      vat: ['', [Validators.required]],
      leaseNumber: ['', [Validators.required]],
      otherCharges: ['', [Validators.required]],
      rentalAmount: ['', [Validators.required]],
      terminationDate: ['', [Validators.required]],
      startingDate: ['', [Validators.required]],
      occupationDate: ['', [Validators.required]],
      escalation: ['', [Validators.required]],
      contactNumber: ['', [Validators.required]],
      capacityofContactPerson: ['', [Validators.required]],
      contactPerson: ['', [Validators.required]],
      postalCode: ['', [Validators.required]],
      leaseStatusTown: ['', [Validators.required]],
      POBox: ['', [Validators.required]],
      IDNumberCompanyRegistrationNumber: ['', [Validators.required]],
      natureOfLease: ['', [Validators.required]],
      magisterialDistrict: ['', [Validators.required]]
    });
    this.improvementForm = this.formBuilder.group({
      buildingName: ['', Validators.required],
      typeOfImprovement: ['', Validators.required],
      sizeofImprovement: ['', [Validators.required]],
      potentialUse: ['', [Validators.required]],
      town: ['', [Validators.required]],
      suburb: ['', [Validators.required]],
      streetName: ['', [Validators.required]],
      streetNumber: ['', [Validators.required]],
      siteCoverag: ['', [Validators.required]],
      functionalPerformanceRating: ['', [Validators.required]],
      extentofBuilding: ['', [Validators.required]],
      conditionRating: ['', [Validators.required]],
      usableArea: ['', [Validators.required]],
    });
    this.financialForm = this.formBuilder.group({
      landUseClass: ['', Validators.required],
      natureofAsset: ['', Validators.required],
      additionCash: ['', [Validators.required]],
      dateofMunicipalValuation: ['', [Validators.required]],
      dateofNonMunicipalValuation: ['', [Validators.required]],
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
        id: this.improvements.length + 1,
        buildingName: this.improvementForm.controls["buildingName"].value,
        type: this.improvementForm.controls["type"].value.name,
        size: this.improvementForm.controls["size"].value,
        potentialUse: this.improvementForm.controls["potentialUse"].value,
        siteCoverag: this.improvementForm.controls["siteCoverag"].value,
        levelofUtilization: this.improvementForm.controls["levelofUtilization"].value,
        extentofBuilding: this.improvementForm.controls["extentofBuilding"].value,
        conditionRating: this.improvementForm.controls["conditionRating"].value.name,
        usableArea: this.improvementForm.controls["usableArea"].value,
        functionalPerformanceRating: this.improvementForm.controls["functionalPerformanceRating"].value.name,
        comment: this.improvementForm.controls["comment"].value,
      };
      this.improvements.push(improvement);
    }
  }
}
