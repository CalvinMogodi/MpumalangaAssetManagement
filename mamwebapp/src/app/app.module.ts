import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GoogleMapsModule } from '@angular/google-maps'
import { CurrencyPipe, DatePipe} from '@angular/common';
import { AutocompleteComponent } from './google-places.component';
// for HttpClient import:
import { LoadingBarHttpClientModule } from '@ngx-loading-bar/http-client';

import { JwtInterceptor } from '../app/helpers/jwt.interceptor';
import { ErrorInterceptor } from '../app/helpers/error.interceptor';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './common/footer/footer.component';
import { SidemenuComponent } from './common/sidemenu/sidemenu.component';
import { HeaderComponent } from './common/header/header.component';
import { LoginComponent } from './common/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { UserComponent } from './components/user/user.component';
import { AddUserComponent } from './components/user/add-user/add-user.component';
import { AssetregisterComponent } from './components/assetregister/assetregister.component'
import { UampComponent } from './components/uamp/uamp.component';
import { CampComponent } from './components/camp/camp.component';
import { ViewUampComponent } from './components/uamp/view-uamp/view-uamp.component'; 
import { TemplateOneComponent } from './components/uamp/template-one/template-one.component';
import { TemplateTwoTwoComponent } from './components/uamp/template-two-two/template-two-two.component';
import { TemplateTwoOneComponent } from './components/uamp/template-two-one/template-two-one.component';
import { TemplateThreeComponent } from './components/uamp/template-three/template-three.component';
import { TemplateFourOneComponent } from './components/uamp/template-four-one/template-four-one.component';
import { TemplateFourTwoComponent } from './components/uamp/template-four-two/template-four-two.component';
import { TemplateFiveOneComponent } from './components/uamp/template-five-one/template-five-one.component';
import { TemplateFiveThreeComponent } from './components/uamp/template-five-three/template-five-three.component';
import { TemplateFiveTwoComponent } from './components/uamp/template-five-two/template-five-two.component';
import { TemplateSevenComponent } from './components/uamp/template-seven/template-seven.component';
import { TemplateSixComponent } from './components/uamp/template-six/template-six.component';
import { ReportFaultComponent } from './components/facilitymanagement/reportfault/report.fault.component'
import { AddMunicipalUtilityServicesComponent } from './components/uamp/template-two-one/add-municipal-utility-services/add-municipal-utility-services';
import { NgxPrintModule } from 'ngx-print';
import { DynamicDialogModule } from 'primeng/dynamicdialog';
import { PanelModule } from 'primeng/panel';
import { ConfirmationService } from 'primeng/api';

import { QrCodeModule } from 'ng-qrcode';

//primeng
import { InputMaskModule } from 'primeng/inputmask';
import { SlideMenuModule } from 'primeng/slidemenu';
import { TimelineModule } from 'primeng/timeline';
import { SidebarModule } from 'primeng/sidebar';
import { MultiSelectModule } from 'primeng/multiselect';
import { ScrollPanelModule } from 'primeng/scrollpanel';
import { OverlayPanelModule } from 'primeng/overlaypanel';
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { ToastModule } from 'primeng/toast';
import { TableModule } from 'primeng/table';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { CheckboxModule } from 'primeng/checkbox';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { TooltipModule } from 'primeng/tooltip';
import { ChartModule } from 'primeng/chart';
import { CardModule } from 'primeng/card';
import { MessageModule} from 'primeng/message';
import { StepsModule } from 'primeng/steps';
import { TabMenuModule } from 'primeng/tabmenu';
import { TabViewModule } from 'primeng/tabview';
import { DropdownModule } from 'primeng/dropdown';
import { FieldsetModule } from 'primeng/fieldset';
import { FileUploadModule } from 'primeng/fileupload';
import { InputTextareaModule}  from 'primeng/inputtextarea';
import { InputNumberModule}  from 'primeng/inputnumber';
import { AddassetregisterComponent } from './components/assetregister/addassetregister/addassetregister.component';
import { FinancialsComponent } from './components/assetregister/addassetregister/financials/financials.component';
import { ImprovementsComponent } from './components/assetregister/addassetregister/improvements/improvements.component';
import { LandComponent } from './components/assetregister/addassetregister/land/land.component';
import { CalendarModule } from 'primeng/calendar';
import { SplitButtonModule } from 'primeng/splitbutton';
import { PrintAssetComponent } from './components/assetregister/print-asset/print-asset.component';
import { SelectButtonModule } from 'primeng/selectbutton';
import { FilterService } from 'primeng/api';
import { PrimeNGConfig } from 'primeng/api';
import { PasswordModule } from 'primeng/password';
import { InputSwitchModule } from 'primeng/inputswitch';
import { DividerModule } from 'primeng/divider';
import { ToggleButtonModule } from 'primeng/togglebutton';
import { RadioButtonModule } from 'primeng/radiobutton';
import { SliderModule} from 'primeng/slider';
import { ContextMenuModule} from 'primeng/contextmenu';
import { ProgressBarModule} from 'primeng/progressbar';
import { InputTextModule} from 'primeng/inputtext';
import { UampDetailsComponent } from './components/uamp/uamp-details/uamp-details.component';
import { ConditionAssessmentComponent } from './components/assetregister/conditionassessment/condition-assessment.component';
import { LeaseManagementComponent } from './components/leasemanagement/lease-management.component';
import { LeasedPropertyComponent } from './components/leasemanagement/leasedproperty/leased-property.component';
import { HiringComponent } from './components/hiring/hiring.component';
import { LeaseRegisterComponent } from './components/lesesregister/leaseregister.component';
import { GooglePlaceModule } from 'ngx-google-places-autocomplete';
import { ProjectComponent } from './components/facilitymanagement/project/project.component';
import { ServiceRequestComponent } from './components/facilitymanagement/servicerequest/service-request.component';
import { FacilityManagementComponent } from './components/facilitymanagement/facility-management.component';
import { AddEditProjectComponent } from './components/facilitymanagement/project/addeditproject/add-edit-project.component';
import { ViewServiceRequestComponent } from './components/facilitymanagement/servicerequest/viewservicerequest/view-service-request.component';

@NgModule({
  declarations: [
    AppComponent,
    AutocompleteComponent,
    TemplateOneComponent,
    FooterComponent,
    HeaderComponent,
    LoginComponent,
    DashboardComponent,
    UserComponent,
    AddUserComponent,
    SidemenuComponent,
    AssetregisterComponent,
    AddassetregisterComponent,
    LandComponent,
    ImprovementsComponent,
    FinancialsComponent,  
    ViewUampComponent,
    ConditionAssessmentComponent,
    PrintAssetComponent,    
    TemplateTwoOneComponent,
    TemplateTwoTwoComponent,
    TemplateThreeComponent,
    TemplateFourOneComponent,
    TemplateFourTwoComponent,
    TemplateFiveOneComponent,
    TemplateFiveTwoComponent,
    TemplateFiveThreeComponent,
    TemplateSixComponent,
    TemplateSevenComponent,
    AddMunicipalUtilityServicesComponent,
    UampComponent,  
    CampComponent,
    UampDetailsComponent,
    LeaseManagementComponent,
    LeasedPropertyComponent,
    HiringComponent,
    LeaseRegisterComponent,
    ProjectComponent,
    ServiceRequestComponent,
    FacilityManagementComponent,
    AddEditProjectComponent,
    ViewServiceRequestComponent,
    ReportFaultComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,    
    HttpClientModule,
    LoadingBarHttpClientModule,
    MessageModule,
    ButtonModule,
    ScrollPanelModule,
    OverlayPanelModule,
    DialogModule,
    ToastModule,
    MultiSelectModule,
    TableModule,
    SlideMenuModule,
    SidebarModule,
    BreadcrumbModule,
    CheckboxModule,
    ConfirmDialogModule,
    TooltipModule,
    ChartModule,
    GoogleMapsModule,
    StepsModule,
    CardModule,
    TabMenuModule,
    TabViewModule,
    DropdownModule,
    FieldsetModule,
    CalendarModule,
    FileUploadModule,
    SplitButtonModule,
    InputTextareaModule,
    NgxPrintModule,
    InputNumberModule,
    DynamicDialogModule,
    PanelModule,
		SliderModule,
		DialogModule,
		MultiSelectModule,
		ContextMenuModule,		
    InputTextModule,
    ProgressBarModule,
    PasswordModule,
    SelectButtonModule,
    ToggleButtonModule,
    InputSwitchModule,
    TimelineModule,
    DividerModule,
    GooglePlaceModule,
    RadioButtonModule,
    InputMaskModule,
    QrCodeModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    CurrencyPipe, FilterService, PrimeNGConfig, ConfirmationService,
    AddMunicipalUtilityServicesComponent, DatePipe
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  entryComponents: [
    AddMunicipalUtilityServicesComponent,
  ]
})
export class AppModule { }
