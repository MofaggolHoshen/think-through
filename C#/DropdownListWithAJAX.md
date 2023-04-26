## Dropdownlist (DDL) with AJAX Call

```JavaScript
<script type="text/javascript">

$(document).ready(function () {

   $("#jBranch").on("change", function () {
          
     var selectedVlue = $(this).val();
     if(selectedVlue)
         {
           $.ajax({
           url: ROOT +"branch/"+ id,
           type: 'GET',
           dataType: "json",
           success: function(results)
                       {
                             var options = '<option>@SharedLocalizer["PleaseSelectText"]</option>';
                             $.each(results, function(i, result)
                              {
                                var option = '<option value="'+result.id+'"';

                                if(@Model.DepartmentId === result.id)
                                         option += 'selected="selected"';

                                    option +='>'+ result.name+'</option>';

                                 options += option;
                                });
                            $("#jDt").html(options);
                        }
                    }); 
            }else{
                var options = '<option>@SharedLocalizer["PleaseSelectText"]</option>';
                $("#jDt").html(options);
            }
    });
});

</script>
```
