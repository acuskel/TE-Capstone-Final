﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.DAO.Interfaces;
using Capstone.Models;
using Capstone.DAO;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private IIssueDAO issueDAO;
        public IssueController(IIssueDAO issueDAO)
        {
            this.issueDAO = issueDAO;
        }
        [HttpGet("{issueId}")]
        public ActionResult<Issue> GetIssue(int issueId)
        {
            return Ok(issueDAO.GetIssue(issueId));
        }

        [HttpGet("All")]
        public ActionResult<Issue> GetAllIssues()
        {
            List<Issue> testIssues = issueDAO.GetAllIssues();
            return Ok(testIssues);
        }


        [HttpPost("{collectionId}")]
        public ActionResult AddIssue(Issue issue, int collectionId)
        {
            bool result = issueDAO.AddIssue(issue.IssueId, collectionId);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{collectionId}/{issueId}")]
        public ActionResult DeleteIssueFromCollection(int collectionId, int issueId)
        {
            bool result = issueDAO.DeleteIssueFromCollection(collectionId, issueId);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }




    }


}
