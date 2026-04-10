<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="RET.Dashboard" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-full xl:ml-[0px]">
        <!-- Navigation Area -->
        <!-- Navigation Area -->
        <nav
          class="px-7 bg-white py-3 flex justify-between items-center shadow-[0px_1px_2px_rgba(0,0,0,0.07)] xl:hidden"
        >
          <!-- **Humburger SVG Icon -->
          <div class="xl:hidden hamburger cursor-pointer">
            <svg
              width="24"
              height="24"
              viewBox="0 0 24 24"
              fill="none"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                fill-rule="evenodd"
                clip-rule="evenodd"
                d="M3 7.125C3 6.50368 3.50368 6 4.125 6H19.875C20.4963 6 21 6.50368 21 7.125C21 7.74632 20.4963 8.25 19.875 8.25H4.125C3.50368 8.25 3 7.74632 3 7.125Z"
                fill="#242424"
              />
              <path
                fill-rule="evenodd"
                clip-rule="evenodd"
                d="M3 12C3 11.3787 3.50368 10.875 4.125 10.875H19.875C20.4963 10.875 21 11.3787 21 12C21 12.6213 20.4963 13.125 19.875 13.125H4.125C3.50368 13.125 3 12.6213 3 12Z"
                fill="#242424"
              />
              <path
                fill-rule="evenodd"
                clip-rule="evenodd"
                d="M3 16.875C3 16.2537 3.50368 15.75 4.125 15.75H19.875C20.4963 15.75 21 16.2537 21 16.875C21 17.4963 20.4963 18 19.875 18H4.125C3.50368 18 3 17.4963 3 16.875Z"
                fill="#242424"
              />
            </svg>
          </div>
          <div class="lg:px-4 flex items-center">
            <img src="images/Logo.svg" />
          </div>
        </nav>
        <!-- Navigation Area Ends Here -->
        <!-- Navigation Area Ends Here -->

        <!-- MainPage -->
        <div class="2xl:pl-20 2xl:pr-10 px-6 py-6 fixw w-full mx-auto">
          <!-- Page Heading -->
          <div
            class="flex flex-col sm:flex-row gap-y-3 sm:items-center justify-between"
          >
            <div class="">
              <h1 class="text-2xl sa700 leading-normal text-gray-800">
                Dashboard
              </h1>
            </div>
            <div class="flex items-center gap-3">
              <div class="relative">
                <div class="group relative">
                  <button
                    onclick="event.stopPropagation();showFilterDropDown('dropdown')"
                    id="dropdownDividerButton"
                    class="bg-white font-normal rounded-lg text-xs text-slate-400 p-2 text-left inline-flex items-center w-[200px] h-12"
                    type="button"
                  >
                    <img
                      src="images/filter-mail-square.svg"
                      alt="Filter"
                      class="mr-2"
                    />
                    <span id="setfilterText1" class="text-sm">Last 7 Days</span>
                    <svg
                      class="ml-auto w-4 h-4"
                      fill="none"
                      stroke="currentColor"
                      viewBox="0 0 24 24"
                      xmlns="http://www.w3.org/2000/svg"
                    >
                      <path
                        stroke-linecap="round"
                        stroke-linejoin="round"
                        stroke-width="2"
                        d="M19 9l-7 7-7-7"
                      ></path>
                    </svg>
                  </button>
                  <div id="dropdown" class="hidden relative drop-shadow">
                    <div
                      class="bg-white w-5 h-5 rotate-45 absolute -top-1 rounded-sm right-2 drop-shadow z-10"
                    ></div>
                    <div
                      class="z-10 md:w-[220px] w-full text-base list-none bg-white shadow pt-3 pb-4 absolute top-[1px] right-0 rounded-xl"
                    >
                      <a
                        href="javascript:void(0)"
                        class="py-2 px-4 text-sm text-slate-700 hover:text-blue-700 hover:font-medium hover:bg-blue-100 hover:rounded"
                        >Approved
                      </a>
                      <a
                        href="javascript:void(0)"
                        class="py-2 px-4 text-sm text-slate-700 hover:text-blue-700 hover:font-medium hover:bg-blue-100 hover:rounded"
                        >Success</a
                      >
                      <a
                        href="javascript:void(0)"
                        class="py-2 px-4 text-sm text-slate-700 hover:text-blue-700 hover:font-medium hover:bg-blue-100 hover:rounded"
                        >Last 7 Days</a
                      >
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <!-- Page Heading -->
          <!-- Stats -->
          <div
            class="flex xl:flex-nowrap flex-wrap mt-6 gap-4 xl:justify-between lg:justify-start justify-start w-full"
          >
            <!-- card 1 -->
            <div
              class="bg-white px-6 py-4 flex flex-col justify-center items-start my-shadow rounded-2xl md:w-full w-full h-[120px]"
            >
              <div class="flex justify-between gap-4 items-center w-full mb-4">
                <h1 class="text-slate-950 text-[32px] sa900">07</h1>
                <div
                  class="w-[45px] h-[45px] rounded-full flex items-center justify-center bg-[#0560FD] bg-opacity-5"
                >
                  <img src="images/loading.svg" alt="Loading" />
                </div>
              </div>
              <p class="text-gray-500 text-base font-medium">
                Pending Approval
              </p>
            </div>
            <div
              class="bg-white px-6 py-4 flex flex-col justify-center items-start my-shadow rounded-2xl md:w-full w-full h-[120px]"
            >
              <div class="flex justify-between gap-4 items-center w-full mb-4">
                <h1 class="text-slate-950 text-[32px] sa900">02</h1>
                <div
                  class="w-[45px] h-[45px] rounded-full flex items-center justify-center bg-[#ED4646] bg-opacity-5"
                >
                  <img src="images/alert-02.svg" alt="Alert" />
                </div>
              </div>
              <p class="text-gray-500 text-base font-medium">Error</p>
            </div>
            <div
              class="bg-white px-6 py-4 flex flex-col justify-center items-start my-shadow rounded-2xl md:w-full w-full h-[120px]"
            >
              <div class="flex justify-between gap-4 items-center w-full mb-4">
                <h1 class="text-slate-950 text-[32px] sa900">05</h1>
                <div
                  class="w-[45px] h-[45px] rounded-full flex items-center justify-center bg-[#FD6D05] bg-opacity-5"
                >
                  <img src="images/package-remove.svg" alt="Rejected" />
                </div>
              </div>
              <p class="text-gray-500 text-base font-medium">Rejected</p>
            </div>
            <div
              class="bg-white px-6 py-4 flex flex-col justify-center items-start my-shadow rounded-2xl md:w-full w-full h-[120px]"
            >
              <div class="flex justify-between gap-4 items-center w-full mb-4">
                <h1 class="text-slate-950 text-[32px] sa900">24</h1>
                <div
                  class="w-[45px] h-[45px] rounded-full flex items-center justify-center bg-[#7313D3] bg-opacity-5"
                >
                  <img src="images/shipping-loading.svg" alt="Loading" />
                </div>
              </div>
              <p class="text-gray-500 text-base font-medium">Under Query</p>
            </div>
            <div
              class="bg-white px-6 py-4 flex flex-col justify-center items-start my-shadow rounded-2xl md:w-full w-full h-[120px]"
            >
              <div class="flex justify-between gap-4 items-center w-full mb-4">
                <h1 class="text-slate-950 text-[32px] sa900">04</h1>
                <div
                  class="w-[45px] h-[45px] rounded-full flex items-center justify-center bg-[#2DC497] bg-opacity-5"
                >
                  <img src="images/delivery-box-01.svg" alt="Loading" />
                </div>
              </div>
              <p class="text-gray-500 text-base font-medium">Second Item</p>
            </div>
          </div>
          <!-- Stats -->
          <!-- progress & Sales Activity -->
          <div
            class="flex lg:flex-row flex-col-reverse items-center w-full lg:items-stretch justify-center lg:justify-between gap-4 mt-6 rounded-2xl"
          >
            <!-- Declarations Summary-->
            <div
              class="w-full px-6 py-6 bg-white my-shadow flex flex-col justify-center rounded-2xl"
            >
              <div
                class="flex flex-col sm:flex-row gap-3 items-center justify-between"
              >
                <h2 class="text-xl sa700 leading-[27px] text-gray-800">
                  Declarations Summary
                </h2>
                <div class="group relative">
                  <button
                    onclick="event.stopPropagation();showFilterDropDown2('dropdown2')"
                    id="dropdownDividerButton"
                    class="bg-[#F4F6FA] font-normal rounded-lg text-base text-slate-400 py-2 px-3 text-left w-[188px] h-12 flex items-center"
                    type="button"
                  >
                    <span id="setfilterText2">Pending Approval</span>
                    <svg
                      class="ml-auto w-4 h-4"
                      fill="none"
                      stroke="currentColor"
                      viewBox="0 0 24 24"
                      xmlns="http://www.w3.org/2000/svg"
                    >
                      <path
                        stroke-linecap="round"
                        stroke-linejoin="round"
                        stroke-width="2"
                        d="M19 9l-7 7-7-7"
                      ></path>
                    </svg>
                  </button>
                  <div
                    id="dropdown2"
                    class="hidden z-10 w-full text-base list-none bg-slate-100 divide-y divide-gray-100 shadow pt-3 pb-4 absolute top-[50px] left-0"
                  >
                    <a
                      href="javascript:void(0)"
                      class="py-2 px-4 text-sm text-slate-700 hover:text-blue-700 hover:font-medium hover:bg-blue-100 hover:rounded"
                      >Pending Approval
                    </a>
                    <a
                      href="javascript:void(0)"
                      class="py-2 px-4 text-sm text-slate-700 hover:text-blue-700 hover:font-medium hover:bg-blue-100 hover:rounded"
                      >Error
                    </a>
                    <a
                      href="javascript:void(0)"
                      class="py-2 px-4 text-sm text-slate-700 hover:text-blue-700 hover:font-medium hover:bg-blue-100 hover:rounded"
                      >Rejected</a
                    >
                    <a
                      href="javascript:void(0)"
                      class="py-2 px-4 text-sm text-slate-700 hover:text-blue-700 hover:font-medium hover:bg-blue-100 hover:rounded"
                      >Under Query
                    </a>
                    <a
                      href="javascript:void(0)"
                      class="py-2 px-4 text-sm text-slate-700 hover:text-blue-700 hover:font-medium hover:bg-blue-100 hover:rounded"
                      >Second Item
                    </a>
                  </div>
                </div>
              </div>
              <canvas class="w-full h-full pt-4" id="chartjs-1"></canvas>
            </div>
            <!-- Declarations Summary
        -->
            <!-- progress -->
            <div
              class="lg:max-w-[430px] w-full bg-white my-shadow rounded-2xl p-6"
            >
              <div class="flex justify-between gap-2 items-center">
                <h2 class="text-lg sa700 leading-[18px] text-gray-800">
                  Recent Notifications
                </h2>
                <a
                  href="notifications.html"
                  class="text-right text-blue-600 text-sm cursor-pointer hover:underline"
                >
                  View All
                </a>
              </div>
              <div class="mt-6 flex justify-between items-center gap-2">
                <div class="flex items-center gap-5">
                  <div
                    class="w-[45px] h-[45px] rounded-full flex items-center justify-center bg-[#0560FD] bg-opacity-5 relative"
                  >
                    <div
                      class="w-[15px] h-[15px] bg-[#0560FD] border-2 border-white rounded-full absolute right-0 top-0"
                    ></div>
                    <img
                      src="images/notification-03-1.svg"
                      alt="Notifications"
                    />
                  </div>
                  <div>
                    <p class="text-slate-950 text-base sa900">#00987<br /></p>
                    <span class="text-gray-500 text-sm"
                      >This item is in Pending Approval</span
                    >
                  </div>
                </div>
                <p class="text-right text-gray-500 text-xs">23min ago</p>
              </div>
              <div class="mt-6 flex justify-between items-center gap-2">
                <div class="flex items-center gap-5">
                  <div
                    class="w-[45px] h-[45px] rounded-full flex items-center justify-center bg-[#0560FD] bg-opacity-5"
                  >
                    <img
                      src="images/notification-03-1.svg"
                      alt="Notifications"
                    />
                  </div>
                  <div>
                    <p class="text-slate-950 text-base sa900 opacity-50">
                      #00987<br />
                    </p>
                    <span class="text-gray-500 text-sm opacity-70"
                      >This item is Under Query</span
                    >
                  </div>
                </div>
                <p class="text-right text-gray-500 text-xs">1day ago</p>
              </div>
              <div class="mt-6 flex justify-between items-center gap-2">
                <div class="flex items-center gap-5">
                  <div
                    class="w-[45px] h-[45px] rounded-full flex items-center justify-center bg-[#0560FD] bg-opacity-5 relative"
                  >
                    <div
                      class="w-[15px] h-[15px] bg-[#0560FD] border-2 border-white rounded-full absolute right-0 top-0"
                    ></div>
                    <img
                      src="images/notification-03-1.svg"
                      alt="Notifications"
                    />
                  </div>
                  <div>
                    <p class="text-slate-950 text-base sa900">#00987<br /></p>
                    <span class="text-gray-500 text-sm"
                      >This item is Rejected</span
                    >
                  </div>
                </div>
                <p class="text-right text-gray-500 text-xs">02/12/23</p>
              </div>
              <div class="mt-6 flex justify-between items-center gap-2">
                <div class="flex items-center gap-5">
                  <div
                    class="w-[45px] h-[45px] rounded-full flex items-center justify-center bg-[#0560FD] bg-opacity-5"
                  >
                    <img
                      src="images/notification-03-1.svg"
                      alt="Notifications"
                    />
                  </div>
                  <div>
                    <p class="text-slate-950 text-base sa900 opacity-50">
                      Eswaran M.<br />
                    </p>
                    <span class="text-gray-500 text-sm opacity-70"
                      >Added an Item in Declaration</span
                    >
                  </div>
                </div>
                <p class="text-right text-gray-500 text-xs">29/1123</p>
              </div>
            </div>
            <!-- progress -->
          </div>
          <!-- progress & Sales Activity -->
          <div class="flex lg:flex-row flex-col-reverse items-center w-full lg:items-stretch justify-center lg:justify-between gap-4 mt-4 rounded-2xl">
            <!-- Table -->
            <div
              class="overflow-auto my-shadow whitespace-nowrap bg-white rounded-2xl p-6 w-full"
            >
              <h2 class="text-xl sa700 leading-[27px] text-gray-800 mb-4">
                Declarations List
              </h2>
              <table class="w-full bg-white rounded whitespace-nowrap">
                <thead>
                  <tr class="w-full h-10 py-4 px-10 bg-[#F4F6FA] rounded-l-lg">
                    <th
                      class="text-sm font-medium leading-none text-gray-500 pr-6 text-left rounded-l-lg pl-6"
                    >
                      Declaration Type
                    </th>
                    <th
                      class="text-sm font-medium leading-none text-gray-500 pr-6 text-left"
                    >
                      Permit
                    </th>
                    <th
                      class="text-sm font-medium leading-none text-gray-500 pr-6 text-left"
                    >
                      Cancelled
                    </th>
                    <th
                      class="text-sm font-medium leading-none text-gray-500 pr-6 text-left"
                    >
                      Pending
                    </th>
                    <th
                      class="text-sm font-medium leading-none text-gray-500 pr-6 text-left"
                    >
                      Query
                    </th>
                    <th
                      class="text-sm font-medium leading-none text-gray-500 pr-6 text-left"
                    >
                      Rejected
                    </th>
                    <th
                      class="text-sm font-medium leading-none text-gray-500 pr-6 text-left rounded-r-lg"
                    >
                      Error
                    </th>
                  </tr>
                </thead>
                <tbody>
                  <tr class="my-0">
                    <td>
                      <p
                        class="text-slate-950 text-sm font-medium py-2.5 lg:pl-6 pl-6 rounded-l-lg"
                      >
                        In Payment
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p
                        class="text-slate-500 text-sm font-medium py-2.5 rounded-r-lg"
                      >
                        24
                      </p>
                    </td>
                  </tr>
                  <tr class="my-0">
                    <td>
                      <p
                        class="text-slate-950 text-sm font-medium py-2.5 lg:pl-6 pl-6 rounded-l-lg"
                      >
                        In Non-Payment
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p
                        class="text-slate-500 text-sm font-medium py-2.5 rounded-r-lg"
                      >
                        24
                      </p>
                    </td>
                  </tr>
                  <tr class="my-0">
                    <td>
                      <p
                        class="text-slate-950 text-sm font-medium py-2.5 lg:pl-6 pl-6 rounded-l-lg"
                      >
                        Outward
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p
                        class="text-slate-500 text-sm font-medium py-2.5 rounded-r-lg"
                      >
                        24
                      </p>
                    </td>
                  </tr>
                  <tr class="my-0">
                    <td>
                      <p
                        class="text-slate-950 text-sm font-medium py-2.5 lg:pl-6 pl-6 rounded-l-lg"
                      >
                        Transhipment
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p
                        class="text-slate-500 text-sm font-medium py-2.5 rounded-r-lg"
                      >
                        24
                      </p>
                    </td>
                  </tr>
                  <tr class="my-0">
                    <td>
                      <p
                        class="text-slate-950 text-sm font-medium py-2.5 lg:pl-6 pl-6 rounded-l-lg"
                      >
                        Certificate of Origin
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p class="text-slate-500 text-sm font-medium py-2.5">
                        24
                      </p>
                    </td>
                    <td>
                      <p
                        class="text-slate-500 text-sm font-medium py-2.5 rounded-r-lg"
                      >
                        24
                      </p>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
            <!-- Table -->
            <div
            class="lg:max-w-[430px] w-full bg-white my-shadow rounded-2xl p-6"
          >
            <div class="flex justify-between gap-2 items-center">
              <h2 class="text-lg sa700 leading-[18px] text-gray-800">
                Permit List
              </h2>
            </div>
            <div class="mt-6 flex justify-between items-center gap-2">
              <div class="flex items-center gap-5">
                <div
                  class="w-[45px] h-[45px] rounded-full flex items-center justify-center bg-[#0560FD] bg-opacity-5 relative"
                >
                  <img
                    src="images/permit-box.svg"
                    alt="Notifications"
                  />
                </div>
                <div>
                  <p class="text-slate-950 text-base sa900">Condition Code: G1<br /></p>
                  <span class="text-gray-500 text-sm"
                    >Total Declaration 03</span
                  >
                </div>
              </div>
            </div>
            <div class="mt-6 flex justify-between items-center gap-2">
              <div class="flex items-center gap-5">
                <div
                  class="w-[45px] h-[45px] rounded-full flex items-center justify-center bg-[#0560FD] bg-opacity-5"
                >
                  <img
                    src="images/permit-box.svg"
                    alt="Notifications"
                  />
                </div>
                <div>
                  <p class="text-slate-950 text-base sa900">
                    Condition Code: G3<br />
                  </p>
                  <span class="text-gray-500 text-sm"
                    >Total Declaration 05</span
                  >
                </div>
              </div>
            </div>
            <div class="mt-6 flex justify-between items-center gap-2">
              <div class="flex items-center gap-5">
                <div
                  class="w-[45px] h-[45px] rounded-full flex items-center justify-center bg-[#0560FD] bg-opacity-5 relative"
                >
                  <img
                    src="images/permit-box.svg"
                    alt="Notifications"
                  />
                </div>
                <div>
                  <p class="text-slate-950 text-base sa900">Condition Code: Z02<br /></p>
                  <span class="text-gray-500 text-sm"
                    >Total Declaration 01</span
                  >
                </div>
              </div>
            </div>
            <div class="mt-6 flex justify-between items-center gap-2">
              <div class="flex items-center gap-5">
                <div
                  class="w-[45px] h-[45px] rounded-full flex items-center justify-center bg-[#0560FD] bg-opacity-5"
                >
                  <img
                    src="images/permit-box.svg"
                    alt="Notifications"
                  />
                </div>
                <div>
                  <p class="text-slate-950 text-base sa900">
                    Condition Code: Z18<br />
                  </p>
                  <span class="text-gray-500 text-sm"
                    >Total Declaration 00</span
                  >
                </div>
              </div>
            </div>
          </div>
          </div>
        </div>
        <!-- MainPage -->
      </div>

        <!-- Existing controls -->
        <asp:FileUpload ID="fuExcel" runat="server" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update Controlled Status" OnClick="btnUpdate_Click" />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
        

       <style>
      canvas {
        width: 100% !important;
        /* height: 100% !important; */
        max-height: 480px !important;
      }

      .checkbox:checked + .check-icon {
        display: flex;
      }

      /* Header styles */
      .first-item::after {
        content: "";
        position: absolute;
        height: 100%;
        width: 1px;
        background-color: #dbeafe;
        top: 40px;
        left: 50%;
        z-index: -1;
      }

      .scrollList::-webkit-scrollbar {
        width: 4px;
      }

      .scrollList::-webkit-scrollbar-track {
        border-radius: 50px;
        background: #ffffff;
      }

      .scrollList::-webkit-scrollbar-thumb {
        background: #dbeafe;
        border-radius: 10px;
      }
      #style-2::-webkit-scrollbar-track {
        -webkit-box-shadow: inset 0 0 6px rgba(241, 241, 241, 0.3);
        border-radius: 10px;
        background-color: #dbeafe;
      }

      #style-2::-webkit-scrollbar {
        width: 6px;
        background-color: #dbeafe;
      }

      #style-2::-webkit-scrollbar-thumb {
        border-radius: 10px;
        -webkit-box-shadow: inset 0 0 6px rgba(0, 0, 0, 0.3);
        background-color: #dbeafe;
      }
      .imgContainer img {
        width: 32px !important;
        height: 32px !important;
      }

      /* Header styles */
    </style>


</asp:Content>
