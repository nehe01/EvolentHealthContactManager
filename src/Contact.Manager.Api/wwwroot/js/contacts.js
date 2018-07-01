$(document).ready(function () {
	$('#get-contact').click(function () {
		getContacts();
	});
});

let apiUrl = 'http://localhost:64984/api/Contacts/';

function getContacts() {
	$.ajax({
		url: apiUrl,
		type: "Get",
		success: function (data) {
			$("#contacts").find("tr:not(:first)").remove();
			for (var i = 0; i < data.length; i++) {
				if (data[i].status == true) { data[i].status = "Active"; } else data[i].status = "Inactive";
				$('<tr>' +
					'<td id="firstNameColumn">' + data[i].firstName + '</td>' +
					'<td id="lastNameColumn">' + data[i].lastName + '</td>' +
					'<td id="emailColumn">' + data[i].email + '</td>' +
					'<td id="phoneNumberColumn">' + data[i].phoneNumber + '</td>' +
					'<td id="statusColumn">' + data[i].status + '</td>' +
					'<td id="actionColumn">' + '<span><i class="fa fa-trash" onclick="deleteContact(' + data[i].id + ')" aria-hidden="true"></i></span>&nbsp;&nbsp;' +
					'<button class="btn edit" id="updateField"><i class="fa fa-pencil" aria-hidden="true"></i></button><button id="saveField" onclick="updateContact(this, ' + data[i].id  +')" class="btn btn-primary hide" style="display:none;">save</button>' + '</td>' +
					'</tr> 	</tbody>').appendTo("#contacts");
			}
		}
	});
}

$(document).on('click', '#updateField', function () {
	$('#contacts').find('.btn-primary').hide();
	$('#contacts').find('.edit').show();
	$(this).hide().siblings('#saveField').css({ "display": "block" });
	$(this).closest('tr').attr('contenteditable', 'true');
	$(this).closest('tr').find('#statusColumn').add().html('<select><option name="tdStatus" value="true" selected="selected"> Active</option><option name="tdStatus" value="false">Inactive</option></select>');
	$(this).closest('tr').find('#actionColumn').attr('contenteditable', 'false');
});

function updateContact(current, id) {		
	var contactInfo = {
		Id: id,
		FirstName: $(current).closest("tr").find("#firstNameColumn").text(),
		LastName: $(current).closest("tr").find("#lastNameColumn").text(),
		Email: $(current).closest("tr").find("#emailColumn").text(),
		PhoneNumber: $(current).closest("tr").find("#phoneNumberColumn").text(),
		Status: $(current).closest('tr').find('#statusColumn').find('option[name="tdStatus"]:selected').val()
	};

	$.ajax({
		url: apiUrl + id,
		type: "Put",
		data: JSON.stringify(contactInfo),
		contentType: 'application/json; charset=utf-8',
		success: function (result) {
			alert('Updated Successfully');
			$('#saveField').hide();
			$('#updateField').show();
			getContacts();
		},
		error: function (msg) { alert(msg); }
	});
}

function saveContact() {
	var contactInfo = {
		FirstName: $("#firstName").val(),
		LastName: $("#lastName").val(),
		Email: $("#email").val(),
		PhoneNumber: $("#phoneNumber").val(),
		Status: $("option[name='status']:selected").val()
	};

	$.ajax({
		type: 'POST',
		url: apiUrl,
		dataType: 'json',
		contentType: 'application/json; charset=utf-8',
		data: JSON.stringify(contactInfo),
		success: function (result) {
			alert('New contact added');
			closeModal();			
			getContacts();
		},
		error: function () { alert('error'); }
	});
}

function deleteContact(id) {
	$.ajax({
		url: apiUrl + id,
		type: 'DELETE',
		success: function (result) {
			getContacts();
		}
	});
}

function openModal() {
	$(".modal").css({ display: "block" });
}

function closeModal() {
	$(".modal").css({ display: "none" });
	$('input[class=form-control]').each(function () {
		$(this).val('');
	});
}

