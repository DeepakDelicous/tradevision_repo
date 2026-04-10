function showFilterOptions(c) {
  const val = document.getElementById(c);
  activeComponentChecker(val);

  val.classList.toggle("hidden");
  val.classList.toggle("z-10");
}
const user = document.getElementById("add-user");
const tooltip = document.querySelectorAll(".tooltipDiv");
function toggleAddUser() {
  activeComponentChecker(null);
  user.classList.toggle("hidden");
}
tooltip.forEach((e) => {
  e.addEventListener("click", (y) => {
    e.classList.toggle("active");
    e.classList.toggle("hidden");
  });
});
function openTableMenuD(element) {
  activeComponentChecker(null);
  tooltip.forEach((e) => {
    // console.log(element.parentElement.children[1]);
    if (
      e.classList.contains("active") &&
      e != element.parentElement.children[0]
    ) {
      e.classList.toggle("hidden");
      e.classList.toggle("active");
    }
  });

  element.parentElement.children[0].classList.toggle("hidden");
  element.parentElement.children[0].classList.toggle("active");
  // console.log(element.parentElement.children[0]);
}
function toggleDropdown2(e) {
  const element = document.getElementById("handleClick");
  activeComponentChecker(element);
  element.classList.toggle("hidden");
}
function showFilterDropDown(id) {
  // activeComponentChecker();
  document.getElementById(id).classList.toggle("hidden");
  // document.getElementById(id).classList.toggle("z-10");
  document.querySelectorAll(`#${id} a`).forEach((a) => {
    a.style.cursor = "pointer";
    a.style.display = "block";

    a.addEventListener("click", function (e) {
      console.log(e.target.textContent);
      document.getElementById("setfilterText1").innerText =
        e.target.textContent;
        document.getElementById("setfilterText1").style.color = "#040415";
      document.getElementById(id).classList.add("hidden");
    });
  });
}
function showFilterDropDown2(id) {
  // activeComponentChecker();
  document.getElementById(id).classList.toggle("hidden");
  // document.getElementById(id).classList.toggle("z-10");
  document.querySelectorAll(`#${id} a`).forEach((a) => {
    a.style.cursor = "pointer";
    a.style.display = "block";

    a.addEventListener("click", function (e) {
      console.log(e.target.textContent);
      document.getElementById("setfilterText2").innerText =
        e.target.textContent;
        document.getElementById("setfilterText2").style.color = "#040415";

      document.getElementById(id).classList.add("hidden");
    });
  });
}
function showFilterDropDown3(id) {
  // activeComponentChecker();
  document.getElementById(id).classList.toggle("hidden");
  // document.getElementById(id).classList.toggle("z-10");
  document.querySelectorAll(`#${id} a`).forEach((a) => {
    a.style.cursor = "pointer";
    a.style.display = "block";

    a.addEventListener("click", function (e) {
      console.log(e.target.textContent);
      document.getElementById("setfilterText3").innerText =
        e.target.textContent;
        document.getElementById("setfilterText3").style.color = "#040415";

      document.getElementById(id).classList.add("hidden");
    });
  });
}
function showFilterDropDown4(id) {
  // activeComponentChecker();
  document.getElementById(id).classList.toggle("hidden");
  // document.getElementById(id).classList.toggle("z-10");
  document.querySelectorAll(`#${id} a`).forEach((a) => {
    a.style.cursor = "pointer";
    a.style.display = "block";

    a.addEventListener("click", function (e) {
      console.log(e.target.textContent);
      document.getElementById("setfilterText4").innerText =
        e.target.textContent;
        document.getElementById("setfilterText4").style.color = "#040415";
      document.getElementById(id).classList.add("hidden");
    });
  });
}
function showFilterDropDown5(id) {
  // activeComponentChecker();
  document.getElementById(id).classList.toggle("hidden");
  // document.getElementById(id).classList.toggle("z-10");
  document.querySelectorAll(`#${id} a`).forEach((a) => {
    a.style.cursor = "pointer";
    a.style.display = "block";

    a.addEventListener("click", function (e) {
      console.log(e.target.textContent);
      document.getElementById("setfilterText5").innerText =
        e.target.textContent;
        document.getElementById("setfilterText5").style.color = "#040415";
      document.getElementById(id).classList.add("hidden");
    });
  });
}
function showFilterDropDown6(id) {
  // activeComponentChecker();
  document.getElementById(id).classList.toggle("hidden");
  // document.getElementById(id).classList.toggle("z-10");
  document.querySelectorAll(`#${id} a`).forEach((a) => {
    a.style.cursor = "pointer";
    a.style.display = "block";

    a.addEventListener("click", function (e) {
      console.log(e.target.textContent);
      document.getElementById("setfilterText6").innerText =
        e.target.textContent;
        document.getElementById("setfilterText6").style.color = "#040415";
      document.getElementById(id).classList.add("hidden");
    });
  });
}
function showFilterDropDown7(id) {
  // activeComponentChecker();
  document.getElementById(id).classList.toggle("hidden");
  // document.getElementById(id).classList.toggle("z-10");
  document.querySelectorAll(`#${id} a`).forEach((a) => {
    a.style.cursor = "pointer";
    a.style.display = "block";

    a.addEventListener("click", function (e) {
      console.log(e.target.textContent);
      document.getElementById("setfilterText7").innerText =
        e.target.textContent;
        document.getElementById("setfilterText7").style.color = "#040415";
      document.getElementById(id).classList.add("hidden");
    });
  });
}
function showFilterDropDown8(id) {
  // activeComponentChecker();
  document.getElementById(id).classList.toggle("hidden");
  // document.getElementById(id).classList.toggle("z-10");
  document.querySelectorAll(`#${id} a`).forEach((a) => {
    a.style.cursor = "pointer";
    a.style.display = "block";

    a.addEventListener("click", function (e) {
      console.log(e.target.textContent);
      document.getElementById("setfilterText8").innerText =
        e.target.textContent;
        document.getElementById("setfilterText8").style.color = "#040415";
      document.getElementById(id).classList.add("hidden");
    });
  });
}
function showFilterDropDown9(id) {
  // activeComponentChecker();
  document.getElementById(id).classList.toggle("hidden");
  // document.getElementById(id).classList.toggle("z-10");
  document.querySelectorAll(`#${id} a`).forEach((a) => {
    a.style.cursor = "pointer";
    a.style.display = "block";

    a.addEventListener("click", function (e) {
      console.log(e.target.textContent);
      document.getElementById("setfilterText9").innerText =
        e.target.textContent;
        document.getElementById("setfilterText9").style.color = "#040415";
      document.getElementById(id).classList.add("hidden");
    });
  });
}
function showFilterDropDown10(id) {
  // activeComponentChecker();
  document.getElementById(id).classList.toggle("hidden");
  // document.getElementById(id).classList.toggle("z-10");
  document.querySelectorAll(`#${id} a`).forEach((a) => {
    a.style.cursor = "pointer";
    a.style.display = "block";

    a.addEventListener("click", function (e) {
      console.log(e.target.textContent);
      document.getElementById("setfilterText10").innerText =
        e.target.textContent;
        document.getElementById("setfilterText10").style.color = "#040415";
      document.getElementById(id).classList.add("hidden");
    });
  });
}
function showFilterDropDown11(id) {
  // activeComponentChecker();
  document.getElementById(id).classList.toggle("hidden");
  // document.getElementById(id).classList.toggle("z-10");
  document.querySelectorAll(`#${id} a`).forEach((a) => {
    a.style.cursor = "pointer";
    a.style.display = "block";

    a.addEventListener("click", function (e) {
      console.log(e.target.textContent);
      document.getElementById("setfilterText11").innerText =
        e.target.textContent;
        document.getElementById("setfilterText11").style.color = "#040415";
      document.getElementById(id).classList.add("hidden");
    });
  });
}
function showFilterDropDown12(id) {
  // activeComponentChecker();
  document.getElementById(id).classList.toggle("hidden");
  // document.getElementById(id).classList.toggle("z-10");
  document.querySelectorAll(`#${id} a`).forEach((a) => {
    a.style.cursor = "pointer";
    a.style.display = "block";

    a.addEventListener("click", function (e) {
      console.log(e.target.textContent);
      document.getElementById("setfilterText12").innerText =
        e.target.textContent;
        document.getElementById("setfilterText12").style.color = "#040415";
      document.getElementById(id).classList.add("hidden");
    });
  });
}
function showFilterDropDown13(id) {
  // activeComponentChecker();
  document.getElementById(id).classList.toggle("hidden");
  // document.getElementById(id).classList.toggle("z-10");
  document.querySelectorAll(`#${id} a`).forEach((a) => {
    a.style.cursor = "pointer";
    a.style.display = "block";

    a.addEventListener("click", function (e) {
      console.log(e.target.textContent);
      document.getElementById("setfilterText13").innerText =
        e.target.textContent;
        document.getElementById("setfilterText13").style.color = "#040415";
      document.getElementById(id).classList.add("hidden");
    });
  });
}
function showFilterDropDown14(id) {
  // activeComponentChecker();
  document.getElementById(id).classList.toggle("hidden");
  // document.getElementById(id).classList.toggle("z-10");
  document.querySelectorAll(`#${id} a`).forEach((a) => {
    a.style.cursor = "pointer";
    a.style.display = "block";

    a.addEventListener("click", function (e) {
      console.log(e.target.textContent);
      document.getElementById("setfilterText14").innerText =
        e.target.textContent;
        document.getElementById("setfilterText14").style.color = "#040415";
      document.getElementById(id).classList.add("hidden");
    });
  });
}
function showFilterDropDown15(id) {
  // activeComponentChecker();
  document.getElementById(id).classList.toggle("hidden");
  // document.getElementById(id).classList.toggle("z-10");
  document.querySelectorAll(`#${id} a`).forEach((a) => {
    a.style.cursor = "pointer";
    a.style.display = "block";

    a.addEventListener("click", function (e) {
      console.log(e.target.textContent);
      document.getElementById("setfilterText15").innerText =
        e.target.textContent;
        document.getElementById("setfilterText15").style.color = "#040415";
      document.getElementById(id).classList.add("hidden");
    });
  });
}

function membersbtn() {
  const el = document.querySelector("#members-interaction");
  activeComponentChecker(el);
  // event.stopPropagation();

  el.classList.toggle("hidden");
}
//
document
  .querySelector("body")
  .addEventListener("click", activeComponentChecker);
//
function activeComponentChecker(el) {
  tooltip.forEach((e) => {
    // console.log(element.parentElement.children[1]);
    if (e.classList.contains("active")) {
      e.classList.add("hidden");
      e.classList.remove("active");
    }
  });
  const el1 = document.getElementById("handleClick");
  const el2 = document.getElementById("handleClick1");
  const el3 = document.getElementById("dropdown");
  const el4 = document.getElementById("members-interaction");
  const el5 = document.getElementById("overview-interaction");
  const el6 = document.getElementById("dropdown2");
  const el7 = document.getElementById("dropdown3");
  const el8 = document.getElementById("dropdown4");
  const el9 = document.getElementById("dropdown5");
  const el10 = document.getElementById("dropdown6");
  const el11 = document.getElementById("dropdown7");
  const el12 = document.getElementById("dropdown8");
  const el13 = document.getElementById("dropdown9");
  const el14 = document.getElementById("dropdown10");
  const el15 = document.getElementById("dropdown11");
  const el16 = document.getElementById("dropdown12");
  const el17 = document.getElementById("dropdown13");
  const el18 = document.getElementById("dropdown14");
  const el19 = document.getElementById("dropdown15");

  if (el1 && el1 != el) {
    if (!el1.classList.contains("hidden")) {
      el1.classList.toggle("hidden");
      el1.classList.toggle("z-10");
      console.log("function call el1");
    }
  }
  if (el2 && el2 != el) {
    if (!el2.classList.contains("hidden")) {
      el2.classList.toggle("hidden");
      el2.classList.toggle("z-10");
      console.log("function call el2");
    }
  }
  if (el3 && el3 != el) {
    if (!el3.classList.contains("hidden")) {
      el3.classList.toggle("hidden");
    }
  }
  if (el6 && el6 != el) {
    if (!el6.classList.contains("hidden")) {
      el6.classList.toggle("hidden");
    }
  }
  if (el7 && el7 != el) {
    if (!el7.classList.contains("hidden")) {
      el7.classList.toggle("hidden");
    }
  }
  if (el8 && el8 != el) {
    if (!el8.classList.contains("hidden")) {
      el8.classList.toggle("hidden");
    }
  }
  if (el9 && el9 != el) {
    if (!el9.classList.contains("hidden")) {
      el9.classList.toggle("hidden");
    }
  }
  if (el10 && el10 != el) {
    if (!el10.classList.contains("hidden")) {
      el10.classList.toggle("hidden");
    }
  }
  if (el11 && el11 != el) {
    if (!el11.classList.contains("hidden")) {
      el11.classList.toggle("hidden");
    }
  }
  if (el12 && el12 != el) {
    if (!el12.classList.contains("hidden")) {
      el12.classList.toggle("hidden");
    }
  }
  if (el13 && el13 != el) {
    if (!el13.classList.contains("hidden")) {
      el13.classList.toggle("hidden");
    }
  }
  if (el14 && el14 != el) {
    if (!el14.classList.contains("hidden")) {
      el14.classList.toggle("hidden");
    }
  }
  if (el15 && el15 != el) {
    if (!el15.classList.contains("hidden")) {
      el15.classList.toggle("hidden");
    }
  }
  if (el16 && el16 != el) {
    if (!el16.classList.contains("hidden")) {
      el16.classList.toggle("hidden");
    }
  }
  if (el17 && el17 != el) {
    if (!el17.classList.contains("hidden")) {
      el17.classList.toggle("hidden");
    }
  }
  if (el18 && el18 != el) {
    if (!el18.classList.contains("hidden")) {
      el18.classList.toggle("hidden");
    }
  }
  if (el19 && el19 != el) {
    if (!el19.classList.contains("hidden")) {
      el19.classList.toggle("hidden");
    }
  }
  if (el4 && el4 != el) {
    // console.log("function call el4");
    if (!el4.classList.contains("hidden")) {
      el4.classList.toggle("hidden");
      console.log("function call el4");
    }
  }
  if (el5 && el5 != el) {
    // console.log("function call el4");
    if (!el5.classList.contains("hidden")) {
      el5.classList.toggle("hidden");
      console.log("function call el5");
    }
  }
}
