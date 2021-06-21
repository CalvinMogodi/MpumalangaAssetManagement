import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GoogleMapsModule } from '@angular/google-maps'
import { CurrencyPipe} from '@angular/common';
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
import { PropertiesComponent } from './components/properties/properties.component';
import { ViewPropertyComponent } from './components/properties/view-property/view-property.component';
import { TemplateOneComponent } from './components/properties/template-one/template-one.component';
import { TemplateTwoTwoComponent } from './components/properties/template-two-two/template-two-two.component';
import { TemplateTwoOneComponent } from './components/properties/template-two-one/template-two-one.component';
import { TemplateThreeComponent } from './components/properties/template-three/template-three.component';
import { TemplateFourOneComponent } from './components/properties/template-four-one/template-four-one.component';
import { TemplateFourTwoComponent } from './components/properties/template-four-two/template-four-two.component';
import { TemplateFiveOneComponent } from './components/properties/template-five-one/template-five-one.component';
import { TemplateFiveThreeComponent } from './components/properties/template-five-three/template-five-three.component';
import { TemplateFiveTwoComponent } from './components/properties/template-five-two/template-five-two.component';
import { TemplateSevenComponent } from './components/properties/template-seven/template-seven.component';
import { TemplateSixComponent } from './components/properties/template-six/template-six.component';
import { NgxPrintModule } from 'ngx-print';
import { DynamicDialogModule } from 'primeng/dynamicdialog';

//primeng
import { SlideMenuModule } from 'primeng/slidemenu';
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
import { AddMunicipalUtilityServicesComponent } from './components/properties/template-two-one/add-municipal-utility-services/add-municipal-utility-services';

@NgModule({
  declarations: [
    AppComponent,
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
    PropertiesComponent,
    ViewPropertyComponent,
    PrintAssetComponent,   
    TemplateOneComponent,
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
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
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
    DynamicDialogModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    CurrencyPipe,
    AddMunicipalUtilityServicesComponent
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  entryComponents: [
    AddMunicipalUtilityServicesComponent,
  ]
})
export class AppModule { }
